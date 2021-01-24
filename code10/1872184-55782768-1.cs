    Task DelayAsync()
    {
        var tcs = new TaskCompletionSource<object>();
        var awaiter = Task.Delay(3000).GetAwaiter();
        if (!awaiter.IsCompleted)
        {
            awaiter.OnCompleted(() =>
            {
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
        return tcs.Task;
    }
