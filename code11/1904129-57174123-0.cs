    private static Task<TResult> RunAbortable<TResult>(Func<TResult> function,
        CancellationToken cancellationToken)
    {
        var tcs = new TaskCompletionSource<TResult>();
        var thread = new Thread(() =>
        {
            try
            {
                TResult result;
                using (cancellationToken.Register(Thread.CurrentThread.Abort))
                {
                    result = function();
                }
                tcs.SetResult(result);
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
            }
        });
        thread.IsBackground = true;
        thread.Start();
        return tcs.Task;
    }
