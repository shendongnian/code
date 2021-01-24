    Parallel.ForEach(
        _workerServices,
        new ParallelOptions { MaxDegreeOfParallelism = 3 },
        workerService => workerService.DoWorkAsync()
            .ContinueWith(res => 
            {
                // Handle your result or possible exceptions by consulting res.
            })
            .Wait());
As you mentioned that previously your code was executing sequentially, I assume that the workers also have a non-async equivalent. It is probably easier to use those. For calling an async method synchronously is mostly a hassle. I've even had deadlock scenarios just by calling `DoWorkAsync().Wait()`. There has been much discussion of https://stackoverflow.com/questions/5095183/how-would-i-run-an-async-taskt-method-synchronously. In essence I try to avoid it. If that is not possible, I attempt to use `ContinueWith` which increases the complexity, or `AsyncHelper` of the previous SO-discussion.
    var results = new ConcurrentDictionary<WorkerService, bool>();
    Parallel.ForEach(
        _workerServices,
        new ParallelOptions { MaxDegreeOfParallelism = 3 },
        workerService => 
            {
                // Handle possible exceptions via try-catch.
                results.TryAdd(workerService, workerService.DoWork());
            });
    // evaluate results
`Parallel.ForEach` takes advantage of a Thread- or TaskPool. Meaning it dispatches every execution of the given parameter `Action<TSource> body` onto a dedicated thread. You can easily verify that with the following code. If `Parallel.ForEach` already dispatches the work on different Threads you can simply execute your 'expensive' operation synchronously. Any async operations would be unnecessary or even have bad impact on runtime performance.
    Parallel.ForEach(
        Enumerable.Range(1, 4),
        m => Console.WriteLine(Thread.CurrentThread.ManagedThreadId));
This is the demo project I used for testing which does not rely on your workerService.
    private static bool DoWork()
    {
        Thread.Sleep(5000);
        Console.WriteLine($"done by {Thread.CurrentThread.ManagedThreadId}.");
        return DateTime.Now.Millisecond % 2 == 0;
    }
    private static Task<bool> DoWorkAsync() => Task.Run(DoWork);
    private static void Main(string[] args)
    {
        var sw = new Stopwatch();
        sw.Start();
        // define a thread-safe dict to store the results of the async operation
        var results = new ConcurrentDictionary<int, bool>();
        Parallel.ForEach(
            Enumerable.Range(1, 4), // this replaces the list of workers
            new ParallelOptions { MaxDegreeOfParallelism = 3 },
            // m => results.TryAdd(m, DoWork()), // this is the alternative synchronous call
            m => DoWorkAsync().ContinueWith(res => results.TryAdd(m, res.Result)).Wait());
        sw.Stop();
        // print results
        foreach (var item in results)
        {
            Console.WriteLine($"{item.Key}={item.Value}");
        }
        Console.WriteLine(sw.Elapsed.ToString());
        Console.ReadLine();
    }
