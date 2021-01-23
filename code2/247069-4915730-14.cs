    using System;
    
    class X { }
    
    class Program
    {
        private X x;
        
        private X xNull = null;
        private X xNotNull = new X();
        
        private void Method1Null()
        {
            x = xNull;
            if (x == null) x = xNotNull;
        }
    
        private void Method2Null()
        {
            x = xNull;
            x = x ?? xNotNull;
        }
    
        private void Method1NotNull()
        {
            x = xNotNull;
            if (x == null) x = xNotNull;
        }
    
        private void Method2NotNull()
        {
            x = xNotNull;
            x = x ?? xNotNull;
        }
    
        private const int repetitions = 1000000000;
    
        private void Time(Action action)
        {
            DateTime start = DateTime.UtcNow;
            for (int i = 0; i < repetitions; ++i)
            {
                action();
            }
            DateTime end = DateTime.UtcNow;
            Console.WriteLine(repetitions / (end - start).TotalSeconds);
        }
    
        private void Run()
        {
            Time(() => { Method1Null(); });
            Time(() => { Method2Null(); });
            Time(() => { Method1NotNull(); });
            Time(() => { Method2NotNull(); });
            Console.WriteLine("Finished");
            Console.ReadLine();
        }
    
        private static void Main()
        {
            new Program().Run();
        }
    }
