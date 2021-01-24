    public static Task<TResult> WhenAll<T1, T2, TResult>(
        Task<T1> task1, Task<T2> task2, Func<T1, T2, TResult> factory)
    {
        return Task.WhenAll(task1, task2).ContinueWith(t =>
        {
            var tcs = new TaskCompletionSource<TResult>();
            if (t.IsFaulted)
            {
                tcs.SetException(t.Exception.InnerExceptions);
            }
            else if (t.IsCanceled)
            {
                tcs.SetCanceled();
            }
            else
            {
                tcs.SetResult(factory(task1.Result, task2.Result));
            }
            return tcs.Task;
        }, default, TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Default).Unwrap();
    }
