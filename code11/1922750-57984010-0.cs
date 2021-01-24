    public Task<TResult> FromAsync<TResult>(IAsyncResult asyncResult, Func<IAsyncResult, TResult> endMethod)
    {
        RegisteredWaitHandle handle;
        var tcs = new TaskCompletionSource<object>();
        void OnAsyncResultSignalled(object state, bool timedOut)
        {
            if (asyncResult.IsCompleted)
            {
                handle.Unregister(null);
                tcs.TrySetResult(endMethod(asyncResult));
            }
        }
        handle = ThreadPool.RegisterWaitForSingleObject(
            asyncResult.AsyncWaitHandle,
            OnAsyncResult,
            null,
            TimeSpan.MaxValue,
            false);
        return tcs.Task;
    }
