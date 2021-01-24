    public static async Task<IList<TResult>> Process<TSource, TResult>(
        IList<TSource> source, Func<TSource, Task<TResult>> taskFactory,
        int maxTasksPerInterval, TimeSpan interval)
    {
        var semaphore = new SemaphoreSlim(maxTasksPerInterval);
        var incompleteTasksCount = source.Count;
        var tasks = source.Select(async item =>
        {
            await semaphore.WaitAsync().ConfigureAwait(false);
            try
            {
                var task = taskFactory(item);
                var result = await task.ConfigureAwait(false);
                var cnt = Interlocked.Decrement(ref incompleteTasksCount);
                if (cnt >= maxTasksPerInterval)
                {
                    await Task.Delay(interval).ConfigureAwait(false);
                }
                return result;
            }
            finally
            {
                semaphore.Release();
            }
        }).ToArray();
        return await Task.WhenAll(tasks);
    }
