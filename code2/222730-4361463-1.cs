    class Program
    {
        static readonly BlockingCollection<string> _collection = new BlockingCollection<string>();
        static readonly Random _rand = new Random();
        static volatile bool _finished; // volatile field
        static void Main()
        {
            const int maxTasks = 5;
            var tasks = new List<Task> {
                // startup publisher task...
                Task.Factory.StartNew(() => { 
                    for(var i = 0; i < 1000; i++)
                    {
                        _collection.Add(i + ".mp3");
                    }
                    Console.WriteLine("Publisher finished");
                    _collection.CompleteAdding();
                    _finished = true;
                }),
            };
            for (var i = 0; i < maxTasks; i++)
            {
                tasks.Add(Task.Factory.StartNew(ConsumerTask(i)));
            }
            Task.WaitAll(tasks.ToArray()); // wait for completion
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
                        Process p = new Process();
                        p.StartInfo.FileName = "binary.exe";
                        p.StartInfo.Arguments = item;
                        p.Start();
                        p.WaitForExit();
                        var exitCode = p.ExitCode;
                        // TODO handle exit code
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
