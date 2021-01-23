    public static class PeriodicTask
    {
        public static async Task Run(
            Func<Task> action,
            TimeSpan period,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                if (!cancellationToken.IsCancellationRequested)
                    await action();
                stopwatch.Stop();
                await Task.Delay(period - stopwatch.Elapsed, cancellationToken);
            }
        }
    }
