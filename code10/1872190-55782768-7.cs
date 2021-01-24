    Task DelayAsync()
    {
        var tcs = new TaskCompletionSource<object>();
        try
        {
            var awaiter = Task.Delay(3000).GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                // This is the continuation that causes your deadlock
                try
                {
                    awaiter.GetResult();
                    tcs.SetResult(null);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            });
        }
        catch (Exception ex)
        {
            tcs.SetException(ex);
        }
        return tcs.Task;
    }
