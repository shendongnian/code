    public static async Task<T> WhenFinishedOrCancelled<T>(this Task<T> task, CancellationToken cancellationToken)
    {
        var tcs = new TaskCompletionSource<byte>();
        using (cancellationToken.Register(s => (s as TaskCompletionSource<byte>).TrySetResult(1), tcs))
        {
            if (tcs.Task == await Task.WhenAny(task, tcs.Task))
            {
                throw new OperationCanceledException(cancellationToken);
            }
            tcs.SetCanceled();
        }
        return await task;
    }
