    public static void Wait(Func<CancellationToken, Task> taskFactory,
        ref bool cancel, int pollInterval = 100)
    {
        using (var cts = new CancellationTokenSource())
        {
            var task = taskFactory(cts.Token);
            while (!cancel)
            {
                if (task.Wait(pollInterval)) return;
            }
            cts.Cancel();
            task.Wait();
        }
    }
