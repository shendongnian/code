    private class QueueInfo
    {
        public SemaphoreSlim Semaphore = new SemaphoreSlim(1);
        public int TicketToRide = 0;
        public int Current = 0;
    }
    private static ConcurrentDictionary<MethodInfo, QueueInfo> queues =
        new ConcurrentDictionary<MethodInfo, QueueInfo>();
    public static Task QueueAsync<T1>(Action<T1> action, T1 param1)
    {
        var queue = queues.GetOrAdd(action.Method, key => new QueueInfo());
        var ticket = Interlocked.Increment(ref queue.TicketToRide);
        return Task.Run(async () =>
        {
            while (true) // Loop until our ticket becomes current
            {
                await queue.Semaphore.WaitAsync();
                try
                {
                    if (Interlocked.CompareExchange(ref queue.Current,
                        ticket, ticket - 1) == ticket - 1)
                    {
                        action(param1);
                        break;
                    }
                }
                finally
                {
                    queue.Semaphore.Release();
                }
            }
        });
    }
