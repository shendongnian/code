    private static async Task<TResult[]> RunAsyncThrottled<TSource, TResult>(
        IEnumerable<TSource> items, Func<TSource, Task<TResult>> taskFactory,
        int maxDegreeOfParallelism)
    {
        //...
        foreach (var item in items)
            //...
            var task = taskFactory(item);
            TResult result = await task;
    }
