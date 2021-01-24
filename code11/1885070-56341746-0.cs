    var tasks = new Task[100];
    for (var i = 1; i <= 100; i++)
    {
        tasks[i] = Task.Run(() => Testing(threadId));
    }
    Task.WhenAll(tasks).GetAwaiter().GetResult();
