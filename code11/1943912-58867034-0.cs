    public static TaskAwaiter GetAwaiter(this Thread thread)
    {
        return Task.Run(async () =>
        {
            while (thread.IsAlive)
            {
                await Task.Delay(100).ConfigureAwait(false);
            }
        }).GetAwaiter();
    }
