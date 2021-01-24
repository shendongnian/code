    public static async Task Main(string[] args)
    {
        var task1 = GetDataAsync(100).WithTimeout(50);  // Should timeout after 50 msec
        var task2 = GetDataAsync(200).WithTimeout(300); // Should complete after 200 msec
        var task3 = GetDataAsync(300).WithTimeout(100); // Should timeout after 100 msec
        var stopwatch = Stopwatch.StartNew();
        var results = await Task.WhenAll(task1, task2, task3); // Wait for all
        stopwatch.Stop();
        Console.WriteLine($"Results: {String.Join(", ", results)}");
        Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds} msec");
    }
    private static async Task<int> GetDataAsync(int input) // the input is used as delay
    {
        await Task.Delay(input);
        return input;
    }
    public static Task<T> WithTimeout<T>(this Task<T> task, int timeout)
    {
        var delayTask = Task.Delay(timeout).ContinueWith(t => default(T),
            TaskContinuationOptions.ExecuteSynchronously);
        return Task.WhenAny(task, delayTask).Unwrap();
    }
