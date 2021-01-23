    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace LockPerformanceConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                var stopwatch = new Stopwatch();
                const int LoopCount = (int) (100 * 1e6);
                int counter = 0;
                for (int repetition = 0; repetition < 5; repetition++)
                {
                    stopwatch.Reset();
                    stopwatch.Start();
                    for (int i = 0; i < LoopCount; i++)
                        lock (stopwatch)
                            counter = i;
                    stopwatch.Stop();
                    Console.WriteLine("With lock: {0}", stopwatch.ElapsedMilliseconds);
                    stopwatch.Reset();
                    stopwatch.Start();
                    for (int i = 0; i < LoopCount; i++)
                        counter = i;
                    stopwatch.Stop();
                    Console.WriteLine("Without lock: {0}", stopwatch.ElapsedMilliseconds);
                }
                Console.ReadKey();
            }
        }
    }
