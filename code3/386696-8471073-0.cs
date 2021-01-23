    namespace ConsoleApplication1
    {
        using System;
        using System.Collections.Generic;
        using System.Threading;
    
        internal class Program
        {
            private static readonly Queue<int>[] queues = new Queue<int>[5];
    
            private static readonly object[] syncs = new object[5];
    
            public static void Main(string[] args)
            {
                for (int i = 0; i < 5; i++)
                {
                    queues[i] = new Queue<int>();
                    syncs[i] = new object();
                    var thread = new Thread(ThreadProc);
                    thread.Start(i);
                }
    
                var random = new Random();
                while (true)
                {
                    Thread.Sleep(1000);
                    int index = random.Next(queues.Length);
                    lock (syncs[index])
                    {
                        int message = random.Next(100);
                        queues[index].Enqueue(message);
                        Console.WriteLine("Sending message " + message + " to thread at " + index);
                        Monitor.Pulse(syncs[index]);
                    }
                }
            }
    
            private static void ThreadProc(object data)
            {
                var index = (int)data;
                lock (syncs[index])
                {
                    while (true)
                    {
                        while (queues[index].Count == 0)
                        {
                            Monitor.Wait(syncs[index]);
                        }
    
                        int message = queues[index].Dequeue();
                        Console.WriteLine("Thread at " + index + " received message " + message);
                    }
                }
            }
        }
    }
