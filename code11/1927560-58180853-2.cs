    private static async Task<TResult[]> RunAsyncThrottled<TResult>(
        IEnumerable<Task<TResult>> tasks, int maxDegreeOfParallelism)
    {
        if (tasks is ICollection<Task<TResult>>) throw new ArgumentException(
            "The enumerable should not be materialized.", nameof(tasks));
        //...
        foreach (var task in tasks)
            //...
            TResult result = await task;
    }
