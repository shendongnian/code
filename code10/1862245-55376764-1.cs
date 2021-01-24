    using System;
    using System.Diagnostics;
    using System.Threading;
    namespace ConsoleApp
    {
        public class Program
        {
            public static void Main(params string[] args)
            {
                PerformanceCounterCategory performanceCounterCategory = new PerformanceCounterCategory("Thermal Zone Information");
                var instances = performanceCounterCategory.GetInstanceNames();
                List<PerformanceCounter> temperatureCounters = new List<PerformanceCounter>();
                foreach (string instanceName in instances)
                {
                
                    foreach (PerformanceCounter counter in performanceCounterCategory.GetCounters(instanceName))
                    {
                        if (counter.CounterName == "Temperature")
                        {
                            temperatureCounters.Add(counter);
                        }
                    }
                }
            
                while(true)
                {
                    foreach (PerformanceCounter counter in temperatureCounters)
                    {
                        Console.WriteLine("{0} {1} {2} {3}",counter.CategoryName,counter.CounterName,counter.InstanceName, counter.NextValue());
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Thread.Sleep(500);
                }
            }
        }
    }
