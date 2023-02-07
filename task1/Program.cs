using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Computer> computers = new List<Computer>()
            {
                new Computer() { Code = "A1", ComputerType = "Тип1", ProcessorType = "intel5", ProcessorFrequency = 2400, RAM = 8, VRAM = 4, HDD = 200, Cost = 1100, NumberAvalible = 4 },
                new Computer() { Code = "B1", ComputerType = "Тип2", ProcessorType = "Radeon", ProcessorFrequency = 2133, RAM = 16, VRAM = 8, HDD = 400, Cost = 1400, NumberAvalible = 2 },
                new Computer() { Code = "C1", ComputerType = "Тип3", ProcessorType = "intel5", ProcessorFrequency = 1400, RAM = 32, VRAM = 16, HDD = 600, Cost = 1300, NumberAvalible = 0 },
                new Computer() { Code = "D1", ComputerType = "Тип4", ProcessorType = "Radeon", ProcessorFrequency = 1500, RAM = 8, VRAM = 6, HDD = 600, Cost = 1200, NumberAvalible = 3 },
                new Computer() { Code = "D2", ComputerType = "Тип5", ProcessorType = "intel7", ProcessorFrequency = 1533, RAM = 16, VRAM = 8, HDD = 400, Cost = 1800, NumberAvalible = 6 },
                new Computer() { Code = "C5", ComputerType = "Тип6", ProcessorType = "intel7", ProcessorFrequency = 1977, RAM = 32, VRAM = 10, HDD = 800, Cost = 1900, NumberAvalible = 5 },
                new Computer() { Code = "A2", ComputerType = "Тип7", ProcessorType = "intel3", ProcessorFrequency = 1800, RAM = 16, VRAM = 2, HDD = 1000, Cost = 1100, NumberAvalible = 10 },
                new Computer() { Code = "B4", ComputerType = "Тип1", ProcessorType = "Radeon", ProcessorFrequency = 2200, RAM = 64, VRAM = 8, HDD = 600, Cost = 1990, NumberAvalible = 1 }
            };

            Console.WriteLine( "Введите тип процессора, по которому хотите найти компьютеры");
            string ProcessorType = Console.ReadLine();
            List<Computer> computersByProcessor = computers.Where(computer => computer.ProcessorType == ProcessorType).ToList();
            Print(computersByProcessor);
            Console.WriteLine();

            Console.WriteLine("Введите объем минимального ОЗУ, по которому хотите найти компьютеры");
            int minimumRAM = Convert.ToInt32(Console.ReadLine());
            List<Computer> computersByminimumRAM = computers.Where(computer => computer.RAM >= minimumRAM).ToList();
            Print(computersByminimumRAM);
            Console.WriteLine();

            Console.WriteLine("Все компьютеры, отсортированные по стоимости");
            List<Computer> computersSortedByCost = computers.OrderBy(computer => computer.Cost).ToList();
            Print(computersSortedByCost);
            Console.WriteLine();

            Console.WriteLine("Все компьютеры, сгруппированные по типу процессора");
            IEnumerable<IGrouping<string,Computer>> computersGroupedByProcessorType = computers.GroupBy(computer => computer.ProcessorType);
            foreach (var item in computersGroupedByProcessorType)
            {
                Console.WriteLine(item.Key);
                foreach (var i in item)
                {
                    Console.WriteLine($"Code = {i.Code}, ComputerType = {i.ComputerType}, ProcessorType = {i.ProcessorType}, ProcessorFrequency = {i.ProcessorFrequency}, RAM = {i.RAM}, " +
                        $"VRAM = {i.VRAM}, HDD = {i.HDD}, Cost = {i.Cost}, NumberAvalible = {i.NumberAvalible}");
                }
            }
            Console.WriteLine();

            Console.WriteLine("Самый дешевый компьютер");
            Computer comp = computersSortedByCost.First();
            Console.WriteLine($"Code = {comp.Code}, ComputerType = {comp.ComputerType}, ProcessorType = {comp.ProcessorType}, ProcessorFrequency = {comp.ProcessorFrequency}, RAM = {comp.RAM}, " +
                    $"VRAM = {comp.VRAM}, HDD = {comp.HDD}, Cost = {comp.Cost}, NumberAvalible = {comp.NumberAvalible}");
            Console.WriteLine();

            Console.WriteLine("Самый дорогой компьютер");
            comp = computersSortedByCost.Last();
            Console.WriteLine($"Code = {comp.Code}, ComputerType = {comp.ComputerType}, ProcessorType = {comp.ProcessorType}, ProcessorFrequency = {comp.ProcessorFrequency}, RAM = {comp.RAM}, " +
                    $"VRAM = {comp.VRAM}, HDD = {comp.HDD}, Cost = {comp.Cost}, NumberAvalible = {comp.NumberAvalible}");
            Console.WriteLine();

            Console.WriteLine("Есть ли в наличие какой либо тип компьютера в количестве 30 штук?");
            Console.WriteLine(computers.Exists(computer => computer.NumberAvalible >= 30));



            //Print(computers);
            Console.ReadLine();
        }

        static void Print(List<Computer> computers)
        {
            foreach (Computer comp in computers)
            {
                Console.WriteLine($"Code = {comp.Code}, ComputerType = {comp.ComputerType}, ProcessorType = {comp.ProcessorType}, ProcessorFrequency = {comp.ProcessorFrequency}, RAM = {comp.RAM}, " +
                    $"VRAM = {comp.VRAM}, HDD = {comp.HDD}, Cost = {comp.Cost}, NumberAvalible = {comp.NumberAvalible}");
            }
        }

    }
}
