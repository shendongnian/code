    Action<int> action = i =>
        {
            Console.Write("start {0} ", i);
            Thread.Sleep(5000);
            Console.Write("finish {0} ", i);
        };
    var tasks = Enumerable.Range(0, 100)
        .Select(arg => Task.Factory.StartNew(() => action(arg), CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default))
        .ToArray();
    Task.WaitAll(tasks);
