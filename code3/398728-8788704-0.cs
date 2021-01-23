    using System;
    using System.Diagnostics;
    
    static class P
    {
        static void Main()
        {
    
            Test(1); // for JIT
            Test(1000000);
        }
        static readonly object syncLock = new object();
        static void Test(int count)
        {
            int j = 0;
            var watch = Stopwatch.StartNew();
            for(int i = 0 ; i < count ; i++)
            {
                for (int z = 0; z < 1000; z++)
                    j++;
            }
            watch.Stop();
            long withoutMillis = watch.ElapsedMilliseconds;
            Console.WriteLine("{0}; {1} (no lock)", j, watch.ElapsedMilliseconds);
    
            j = 0;
            watch = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                for (int z = 0; z < 1000; z++ )
                    lock (syncLock)
                    {
                        j++;
                    }
            }
            watch.Stop();
            long withMillis = watch.ElapsedMilliseconds;
            Console.WriteLine("{0}; {1} (lock)", j, watch.ElapsedMilliseconds);
    
            long deltaNano = (withMillis - withoutMillis) * 1000000;
                    // nano = 1000 micro = 1000000 milli
            double perLockNano = deltaNano/(1000.0 * count);
            Console.WriteLine("{0}ns per lock", perLockNano);
        }
    }
