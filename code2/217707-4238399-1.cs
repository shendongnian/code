        const int x = 3000;
        const int y = 1000;
        
        static void Main(string[] args)
        {
            // Your scheduler
            TaskScheduler scheduler = TaskScheduler.Default;
            Task nonblockingTask = new Task(() =>
                {
                    CancellationTokenSource source = new CancellationTokenSource();
                    
                    Task t1 = new Task(() =>
                        {
                            while (true)
                            {
                                // Do something
                                if (source.IsCancellationRequested)
                                    break;
                            }
                        }, source.Token);
                    t1.Start(scheduler);
                    // Wait for task 1
                    bool firstTimeout = t1.Wait(x);
                    if (!firstTimeout)
                    {
                        // If it hasn't finished at first timeout display message
                        Console.WriteLine("Message to user: the operation hasn't completed yet.");
                        bool secondTimeout = t1.Wait(y);
                        if (!secondTimeout)
                        {
                            source.Cancel();
                            Console.WriteLine("Operation stopped!");
                        }
                    }
                });
            nonblockingTask.Start();
            Console.WriteLine("Do whatever you want...");
            Console.ReadLine();
        }
