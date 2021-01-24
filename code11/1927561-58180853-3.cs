    private static async IAsyncEnumerable<TResult> RunAsyncThrottled<TSource, TResult>(
        IEnumerable<TSource> items, Func<TSource, Task<TResult>> taskFactory,
        int maxDegreeOfParallelism)
    {
        //...
        foreach (var item in items)
            //...
            yield return await taskFactory(item);
    }
