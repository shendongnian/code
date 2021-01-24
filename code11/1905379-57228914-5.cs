    Thread.CurrentThread.Name = "Main";
    var dispatcherReady = new TaskCompletionSource<Dispatcher>();
    var thread = new Thread(() =>
    {
        Console.WriteLine($"{Thread.CurrentThread.Name} Started");
        dispatcherReady.SetResult(Dispatcher.CurrentDispatcher);
        Dispatcher.Run();
        Console.WriteLine($"{Thread.CurrentThread.Name} Finished");
    });
    thread.IsBackground = true;
    thread.Name = "Worker";
    thread.Start();
    var dispatcher = dispatcherReady.Task.Result;
    dispatcher.Invoke(() =>
    {
        Console.WriteLine($"Processed by {Thread.CurrentThread.Name}");
    });
    dispatcher.InvokeShutdown();
    thread.Join();
