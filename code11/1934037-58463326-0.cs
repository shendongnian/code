    public static async Task RunSequentially(IEnumerable<Func<Task>> taskFactories,
        int timeout = Timeout.Infinite, bool onTimeoutAwaitIncompleteTask = false)
    {
        using (var cts = new CancellationTokenSource(timeout))
        {
            if (onTimeoutAwaitIncompleteTask)
            {
                await Task.Run(async () =>
                {
                    foreach (var taskFactory in taskFactories)
                    {
                        if (cts.IsCancellationRequested) throw new TimeoutException();
                        await taskFactory();
                    }
                });
            }
            else // On timeout return immediately
            {
                var allSequentially = Task.Run(async () =>
                {
                    foreach (var taskFactory in taskFactories)
                    {
                        cts.Token.ThrowIfCancellationRequested();
                        var task = taskFactory(); // Synchronous part of task
                        cts.Token.ThrowIfCancellationRequested();
                        await task; // Asynchronous part of task
                    }
                }, cts.Token);
                var timeoutTask = new Task(() => {}, cts.Token);
                var completedTask = await Task.WhenAny(allSequentially, timeoutTask);
                if (completedTask.IsCanceled) throw new TimeoutException();
            }
        }
    }
