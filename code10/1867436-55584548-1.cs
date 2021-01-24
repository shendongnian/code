    public async static Task Test()
    {
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        await Task.CompletedTask; // <--- instead of Task.Delay()
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
    }
