    private static ConcurrentDictionary<MethodInfo, SemaphoreSlim> semaphores =
        new ConcurrentDictionary<MethodInfo, SemaphoreSlim>();
    private static Task QueueAsync<T>(Action<T> action, T param1)
    {
        return Task.Run(async () =>
        {
            var semaphore = semaphores
                .GetOrAdd(action.Method, key => new SemaphoreSlim(1));
            await semaphore.WaitAsync();
            try
            {
                action(param1);
            }
            finally
            {
                semaphore.Release();
            }
        });
    }
