    public static async Task<R> UsingAsync<T, R>(this T disposable, Func<T, Task<R>> task)
            where T : IAsyncDisposable
    {
        bool trySucceeded = false;
        R result;
        try
        {
            result = await task(disposable);
            trySucceeded = true;
        }
        finally
        {
            if (trySucceeded)
                await disposable.DisposeAsync();
            else // must suppress exceptions
                try { await disposable.DisposeAsync(); } catch { }
        }
        return result;
    }
