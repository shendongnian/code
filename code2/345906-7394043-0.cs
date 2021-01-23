    static void DoIt(string name)
    {
        Console.WriteLine("Hello {0} | {1} - {2}", name, Thread.CurrentThread.ManagedThreadId, DateTime.Now);
        Thread.Sleep(5000);
        Console.WriteLine("Bye {0} | {1} - {2}", name, Thread.CurrentThread.ManagedThreadId, DateTime.Now);
    }
    static void Main()
    {
        int workerThreads, complete;
        ThreadPool.GetMinThreads(out workerThreads, out complete);
        Console.WriteLine(workerThreads);
        // Comment out this line to see the difference...
        // WIth this commented out, the second iteration will be immediate
        ThreadPool.SetMinThreads(100, complete);
        Action run = () =>
            {
                for (int i = 0; i < 20; ++i)
                {
                    int tmp = i;
                    Task.Factory.StartNew(() => DoIt(tmp.ToString()));
                }
            };
        run();
        Console.WriteLine("Press a key to run again...");
        Console.ReadKey();
        run();
        Console.WriteLine("Press a key to exit...");
        Console.ReadKey();
    }
