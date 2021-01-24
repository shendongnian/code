    var results = Enumerable.Range(1, 10)
        .AsParallel()
        .AsOrdered()
        .WithDegreeOfParallelism(3)
        .WithMergeOptions(ParallelMergeOptions.NotBuffered)
        .Select(x =>
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff}"
                + $" [{Thread.CurrentThread.ManagedThreadId}] Parallel #{x}");
            Thread.Sleep(1000); // Simulate some CPU-bound work
            return x;
        })
        .AsSequential()
        .Select(x =>
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff}"
                + $" [{Thread.CurrentThread.ManagedThreadId}] Sequential #{x}");
            Thread.Sleep(500); // Simulate some CPU-bound work
            return x;
        })
        .ToArray();
    Console.WriteLine($"Results: {String.Join(", ", results)}");
