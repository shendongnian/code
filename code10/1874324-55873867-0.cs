    private IEnumerable<(int, int)> GetNestedFor()
    {
        for (int x = 0; x < 1000; x++)
        {
            for (int y = 0; y < 1000; y++)
            {
                yield return (x, y); // return a ValueTuple<int, int>
            }
        }
    }
    ThreadPool.SetMinThreads(100, 100);
    var options = new ParallelOptions() { MaxDegreeOfParallelism = 100 };
    Parallel.ForEach(GetNestedFor(), options, item =>
    {
        int param1 = item.Item1;
        int param2 = item.Item2;
        Console.WriteLine($"Processing ({param1}, {param2})");
        Thread.Sleep(100); // Simulate some work
    });
