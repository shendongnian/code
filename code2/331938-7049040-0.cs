    using System;
    using System.Diagnostics;
    
    class Test
    {
        const int Iterations = 1000000000;
        
        static void Main()
        {
            AllocateOnce();
            AllocateInLoop();
        }
        
        static void AllocateOnce()
        {
            int x = 10;
    
            Stopwatch sw = Stopwatch.StartNew();
            int sum = 0;
            Func<int, int> allocateOnce = y => y + x;
            for (int i = 0; i < Iterations; i++)
            {
                sum += Apply(i, allocateOnce);
            }
            sw.Stop();
            Console.WriteLine("Allocated once: {0}ms", sw.ElapsedMilliseconds);
        }
    
        static void AllocateInLoop()
        {
            int x = 10;
    
            Stopwatch sw = Stopwatch.StartNew();
            int sum = 0;
            for (int i = 0; i < Iterations; i++)
            {
                sum += Apply(i, y => y + x);
            }
            sw.Stop();
            Console.WriteLine("Allocated in loop: {0}ms", sw.ElapsedMilliseconds);
        }
    
        static int Apply(int loopCounter, Func<int, int> func)
        {
            return func(loopCounter);
        }
    }
