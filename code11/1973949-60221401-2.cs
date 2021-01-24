    public static async Task<IList<TResult>> Process<TSource, TResult>(
        IEnumerable<TSource> source, Func<TSource, Task<TResult>> taskFactory,
        int maxTasksPerInterval, TimeSpan interval)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (taskFactory == null) throw new ArgumentNullException(nameof(taskFactory));
        if (maxTasksPerInterval < 1)
            throw new ArgumentOutOfRangeException(nameof(maxTasksPerInterval));
        if (interval < TimeSpan.Zero)
            throw new ArgumentOutOfRangeException(nameof(interval));
        var semaphore = new SemaphoreSlim(maxTasksPerInterval);
        var incompleteTasksCount = 0;
        var tasks = source.Select(async item =>
        {
            await semaphore.WaitAsync().ConfigureAwait(false);
            try
            {
                var task = taskFactory(item);
                var result = await task.ConfigureAwait(false);
                var cnt = Interlocked.Decrement(ref incompleteTasksCount);
                if (cnt < 0 || cnt >= maxTasksPerInterval)
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
        Interlocked.Add(ref incompleteTasksCount, tasks.Length);
        return await Task.WhenAll(tasks);
    }
