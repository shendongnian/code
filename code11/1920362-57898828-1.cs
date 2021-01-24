    public Task StartAsync(CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            return Task.FromCanceled(cancellationToken);
        var tcs = new TaskCompletionSource<bool>();
        var cancellationRegistration = cancellationToken.Register(() =>
            tcs.TrySetCanceled(cancellationToken));
        var fireAndForget = Task.Run(() =>
        {
            if (cancellationToken.IsCancellationRequested) return;
            try
            {
                Start(() =>
                {
                    cancellationRegistration.Dispose(); // Unregister
                    tcs.TrySetResult(true);
                });
            }
            catch (OperationCanceledException)
            {
                tcs.TrySetCanceled();
                return;
            }
            catch (Exception ex)
            {
                tcs.TrySetException(ex);
                return;
            }
            // At this point Start is completed succesfully. Calling APIAbort is allowed.
            var continuation = tcs.Task.ContinueWith(_ =>
            {
                try
                {
                    APIAbort();
                }
                catch { } // Suppressed
            },  default, TaskContinuationOptions.OnlyOnCanceled
            | TaskContinuationOptions.RunContinuationsAsynchronously,
            TaskScheduler.Default);
        }, cancellationToken);
        return tcs.Task;
    }
