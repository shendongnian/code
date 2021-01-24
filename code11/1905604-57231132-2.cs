    static void Main(string[] args)
        {
            var task0 = new Task(WorkWithSleep("task0"));
            var task1 = new Task(WorkWithSleep("task1"));
            var task2 = new Task(WorkWithSleep("task2"));
            var task3 = new Task(WorkWithSleep("task3"));
            var after0or2 = Task.WhenAny(task0, task2).ContinueWith(t =>
            {
                if (task0.IsCompleted)
                {
                    Task.WhenAll(task2, task1).ContinueWith((tt) => task3.Start());
                    task1.Start();
                }
                else
                {
                    Task.WhenAll(task0, task3).ContinueWith((tt) => task1.Start());
                    task3.Start();
                }
            });
            task0.Start();
            task2.Start();
            var allwork = Task.WhenAll(task0, task1, task2, task3);
            allwork.Wait();
            Console.ReadLine();
        }
        public static Action WorkWithSleep(string name, int wait = 1000)
        {
            return () =>
            {
                Console.WriteLine($"Work:{name} STARTED:{DateTime.Now.ToLongTimeString()}");
                Thread.Sleep(wait); //This will simulate proccesor work
                Console.WriteLine($"Work:{name} ENDED:{DateTime.Now.ToLongTimeString()}");
            };
        }
