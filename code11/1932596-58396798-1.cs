    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    namespace TestConsole
    {
        internal class Program
        {
            private static void Main()
            {
                ConcurrentDictionary<int, string> threadResults = new ConcurrentDictionary<int, string>();
                for (int i = 0; i < 100; i++)
                {
                    new Thread(() =>
                    {
                        while (true)
                        {
                            string data = i.ToString();
                            threadResults.AddOrUpdate(i, data, (id, x) => data);
                            Thread.Sleep(100);
                        }
                    }).Start();
                }
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        foreach (var threadResult in threadResults)
                        {
                            Console.WriteLine($"{threadResult.Key} {threadResult.Value}");
                        }
                        Console.WriteLine();
                        Thread.Sleep(2000);
                    }
                });
                Console.WriteLine("press return to exit...");
                Console.ReadLine();
            }
        }
    }
