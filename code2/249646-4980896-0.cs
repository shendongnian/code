    using System;
    using System.Diagnostics;
    
    class Test
    {
        static void Main()
        {
            Random rng = new Random();
            int[] ks = new int[100000000];
            for (int i = 0; i < ks.Length; i++)
            {
                ks[i] = rng.Next(1000);
            }
            
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Iteration {0}", i);
                long sum = 0;
                Stopwatch sw = Stopwatch.StartNew();
                for (int j = 0; j < ks.Length; j++)
                {
                    int k = ks[j];
                    unsafe
                    {
                        bool input = k > 9;
                        byte A = *((byte*)(&input)); // 1
                        sum += A * (k + 0x37) - (A - 1) * (k + 0x30);
                    }
                }
                sw.Stop();
                Console.WriteLine("Unsafe code: {0}; {1}ms",
                                  sum, sw.ElapsedMilliseconds);
                
                sum = 0;
                sw = Stopwatch.StartNew();
                for (int j = 0; j < ks.Length; j++)
                {
                    int k = ks[j];
                    sum += k > 9 ? k + 0x37 : k + 0x30;
                }
                sw.Stop();
                Console.WriteLine("Conditional: {0}; {1}ms",
                                  sum, sw.ElapsedMilliseconds);
            }
        }
    }
