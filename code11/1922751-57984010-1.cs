    public Task<TResult> FromAsync<TResult>(IAsyncResult asyncResult, Func<IAsyncResult, TResult> endMethod)
    {
        return Task.Run(() =>
        {
            while (!asyncResult.IsCompleted)
                asyncResult.AsyncWaitHandle.WaitOne();
            return endMethod(asyncResult);
        });
    }
