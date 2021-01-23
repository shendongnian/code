    using System;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    using System.Threading;
    class Program
    {
        static readonly BlockingCollection<string> _collection = new BlockingCollection<string>();
        static readonly Random _rand = new Random();
        static volatile bool _finished; // volatile field
        static void Main()
        {
            var tasks = new Task[] {
                // startup publisher task...
                Task.Factory.StartNew(() => { 
                    for(var i = 0; i < 1000; i++)
                    {
                        _collection.Add("mp3_" + i);
                        Thread.Sleep(_rand.Next(10)); // simulate some work
                    }
                    Console.WriteLine("Publisher finished");
                    _collection.CompleteAdding();
                    _finished = true;
                }),
                // startup some consumer tasks
                Task.Factory.StartNew(ConsumerTask(1)),
                Task.Factory.StartNew(ConsumerTask(2)),
                Task.Factory.StartNew(ConsumerTask(3)),
                Task.Factory.StartNew(ConsumerTask(4)),
                Task.Factory.StartNew(ConsumerTask(5)),
            };
            Task.WaitAll(tasks); // wait for completion
        }
        static Action ConsumerTask(int id)
        {
            // return a closure just so the id can get passed
            return () =>
            {
                string item;
                while (true)
                {
                    if (_collection.TryTake(out item, 100))
                    {
                        // here you startup the other process
                        Console.WriteLine("{0} consumed by {1}", item, id);
                        Thread.Sleep(_rand.Next(100)); // simulate some work
                        /*
                         Process p = new Process();
                            p.StartInfo.FileName = "binary.exe";
                            p.StartInfo.Arguments = item;
                            p.Start();
                            p.WaitForExit();
                         */
                    }
                    else if (_finished)
                    {
                        break; // exit loop
                    }
                }
                Console.WriteLine("Consumer {0} finished", id);
            };
        }
    }
