    var tasks = new Task[100];
    for (var i = 0; i < 100; i++)
    {
        int threadId = i;
        tasks[i] = Task.Run(() => Testing(threadId));
    }
    Task.WhenAll(tasks).GetAwaiter().GetResult();
