    using Polly;
    using Polly.Bulkhead;
    
    static async Task Main(string[] args)
    {
        var groupedObjects = Enumerable.Range(0, 10).Select(n => new object[] { n }); // Create 10 sets to work with
        var bulkheadPolicy = Policy.BulkheadAsync(3, 3); // maxParallelization, maxQueuingActions
        var parallelTasks = new List<Task>();
        foreach (var set in groupedObjects)
        {
            Console.WriteLine($"Scheduling, Available: {bulkheadPolicy.BulkheadAvailableCount}, QueueAvailable: {bulkheadPolicy.QueueAvailableCount}");
            var task = bulkheadPolicy.ExecuteAsync(async () => // Schedule the task and return immediately
            {
                await DoSomethingAsync(set).ConfigureAwait(false); // Await the task in another thread without capturing the context
            });
            parallelTasks.Add(task);
            await Task.Delay(50); // Interval between scheduling more tasks
        }
    
        var whenAllTasks = Task.WhenAll(parallelTasks);
        try
        {
            await whenAllTasks; // Await all the tasks (await throws only one of the exceptions)
        }
        catch
        {
            whenAllTasks.Exception.Handle(ex => ex is BulkheadRejectedException); // Ignore rejections, rethrow other exceptions
        }
        Console.WriteLine($"Processed: {parallelTasks.Where(t => t.Status == TaskStatus.RanToCompletion).Count()}");
        Console.WriteLine($"Faulted: {parallelTasks.Where(t => t.IsFaulted).Count()}");
    }
    
    static async Task DoSomethingAsync(IEnumerable<object> set)
    {
        await Task.Delay(500).ConfigureAwait(false); // Pretend we are doing something with the set
    }
