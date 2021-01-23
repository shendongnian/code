        const int x = 3000;
        const int y = 1000;
        
        static void Main(string[] args)
        {
            Task jobTask = new Task(() =>
                {
                    Task t1 = new Task(() =>
                        {
                            Thread.Sleep(5000);
                        });
                    t1.Start();
                    if (!t1.Wait(x))
                    {
                        Console.WriteLine("Waited for {0}ms, no results yet.", x);
                        
                        if (!t1.Wait(y))
                            Console.WriteLine("Waited for other {0}ms, no results yet.", y);
                        else
                            Console.WriteLine("Task finished with waiting!");
                    }
                    else
                        Console.WriteLine("Task finished without waiting!");
                });
            jobTask.Start();
            Console.ReadLine();
        }
