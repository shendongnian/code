    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    namespace TestConsole
    {
        internal class Program
        {
            private static void Main()
            {
                ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
                // start a task running the producers
                Task.Factory.StartNew(() =>
                {
                    // simulate 100 producing 'threads'
                    Enumerable.Range(1, 100).AsParallel().ForAll(x =>
                    {
                        string data = x.ToString();
                        queue.Enqueue(data);
                        Thread.Sleep(100);
                    });
                });
                // start a task running the consumer
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        if (queue.TryDequeue(out var data))
                        {
                            Console.WriteLine(data);
                        }
                    }
                });
                Console.WriteLine("press return to exit...");
                Console.ReadLine();
            }
        }
    }
