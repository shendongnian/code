    using System;
    using System.Diagnostics;
    
    class Program {
        static void Main(string[] args) {
            PerformanceCounter cpuCounter;
            cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";
            cpuCounter.NextValue();
            while (!Console.KeyAvailable) {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine(cpuCounter.NextValue());
            }
        }
    }
