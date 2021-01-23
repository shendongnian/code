    using System;
    using System.Diagnostics;
    using System.Linq;
    static class Test
    {
        static void Main()
        {
            var processorCategory = PerformanceCounterCategory.GetCategories()
                .FirstOrDefault(cat => cat.CategoryName == "Processor");
            var countersInCategory = processorCategory.GetCounters("_Total");
            DisplayCounter(countersInCategory.First(cnt => cnt.CounterName == "% Processor Time"));
        }
        private static void DisplayCounter(PerformanceCounter performanceCounter)
        {
            while (!Console.KeyAvailable)
            {
                Console.WriteLine("{0}\t{1} = {2}",
                    performanceCounter.CategoryName, performanceCounter.CounterName, performanceCounter.NextValue());
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
