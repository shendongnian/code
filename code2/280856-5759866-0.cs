    static void DoIt()
    {
        BlockingCollection<int> items = new BlockingCollection<int>();
        CancellationTokenSource src = new CancellationTokenSource();
        ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Thread started. Waiting for item or cancel.");
                try
                {
                    var x = items.Take(src.Token);
                    Console.WriteLine("Take operation successful.");
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Take operation was canceled. IsCancellationRequested={0}", src.IsCancellationRequested);
                }
            });
        Console.WriteLine("Press ENTER to cancel wait.");
        Console.ReadLine();
        src.Cancel(false);
        Console.WriteLine("Cancel sent. Press Enter when done.");
        Console.ReadLine();
    }
