    private static async Task<T[]> TestThrottled<T>(List<Func<Task<T>>> tasks, int maxDegreeOfParallelism)
    {        
        var tasksParallelized = new List<Task<T>>();
        var semaphore = new SemaphoreSlim(maxDegreeOfParallelism);
        foreach (var task in tasks)
        {
            await semaphore.WaitAsync();
            var taskParallelized = Task.Run(async () =>
            {                
                try
                {
                    return await task.Invoke();
                }
                finally
                {
                    semaphore.Release();
                }
            });
            tasksParallelized.Add(taskParallelized);
        }
                    
        return await Task.WhenAll(tasksParallelized);        
    }
    private static async Task<int> TestAsync()
    {
        await Task.Delay(1000);
        return 1;
    }
    static async Task Main(string[] args)
    {
        var sw = Stopwatch.StartNew();
        var tasks = new List<Func<Task<int>>>();
        var ints = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            tasks.Add(() => TestAsync());
        }
                
        ints.AddRange(await TestThrottled(tasks, 2));
        
        Console.WriteLine($"{sw.Elapsed.TotalMilliseconds}, count: {ints.Count}");
        Console.ReadLine();
    }
