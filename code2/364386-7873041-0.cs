    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    class Program
    {
        public static void Main(string[] args)
        {
            // Make sure we've JITted the LinkedList code
            new LinkedList<string>().AddFirst("ignored");
            
            LinkedList<string> list = new LinkedList<string>();        
            TimeInsert(list);
            list.AddFirst("x");
            TimeInsert(list);
            list.AddFirst("x");
            TimeInsert(list);
            list.AddFirst("x");        
        }
        
        const int Iterations = 100000000;
        
        static void TimeInsert(LinkedList<string> list)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
    
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < Iterations; i++)
            {
                list.AddFirst("item");
                list.RemoveFirst();
            }
            sw.Stop();
            
            Console.WriteLine("Initial size: {0}; Ticks: {1}",
                               list.Count, sw.ElapsedTicks);
        }
    }
