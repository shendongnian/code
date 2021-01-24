    public async static Task Test()
    {
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        await Task.CompletedTask;
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
    }
