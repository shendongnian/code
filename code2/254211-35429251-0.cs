    private TResult InvokeAsyncFuncSynchronously<TResult>(Func< Task<TResult>> func)
        {
            TResult result = default(TResult);
            var autoResetEvent = new AutoResetEvent(false);
            Task.Run(async () =>
            {
                try
                {
                    result = await func();
                }
                catch (Exception exc)
                {
                    mErrorLogger.LogError(exc.ToString());
                }
                finally
                {
                    autoResetEvent.Set();
                }
            });
            autoResetEvent.WaitOne();
            return result;
        }
