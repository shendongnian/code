    Parallel.ForEach(
        _workerServices,
        new ParallelOptions { MaxDegreeOfParallelism = 3 },
        workerService => workerService.DoWorkAsync()
            .ContinueWith(res => 
            {
                // Handle your result or possible exceptions.
            })
            .Wait());
As you mentioned that previously your code was executing sequentially, I assume that the workers also have a non-async equivalent. It is probably easier to use those. For calling an async method synchronously is mostly a hassle.
    Parallel.ForEach(
        _workerServices,
        new ParallelOptions { MaxDegreeOfParallelism = 3 },
        workerService => 
            {
                // Handle your result or possible exceptions.
                var result = workerService.DoWork();
            });
This is the demo project I used for testing which does not rely on your workerService.
    private static Task<bool> DoWorkAsync()
    {
        return Task.Run(() =>
        {
            Thread.Sleep(5000);
            Console.WriteLine($"done by {Thread.CurrentThread.ManagedThreadId}.");
            return DateTime.Now.Millisecond % 2 == 0;
        });
    }
    private static void Main(string[] args)
    {
        var sw = new Stopwatch();
        sw.Start();
        var results = new ConcurrentDictionary<int, bool>();
        Parallel.ForEach(
            Enumerable.Range(1, 4),
            new ParallelOptions { MaxDegreeOfParallelism = 3 },
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
