    using System;
    
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("You have {0} bytes of RAM",
                new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory);
            Console.ReadLine();
        }
    }
