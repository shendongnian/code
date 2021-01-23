    private enum RetryableSqlErrors
    {
        Timeout = -2,
        NoLock = 1204,
        Deadlock = 1205,
        WordbreakerTimeout = 30053,
    }
    private void Retry<T>(Action<T> retryAction) where T : IDisposable, new()
    {
        var retryCount = 0;
        using (var ctx = new T())
        {
            for (;;)
            {
                try
                {
                    retryAction(ctx);
                    break;
                }
                catch (SqlException ex)
                {
                    if (!Enum.IsDefined(typeof( RetryableSqlErrors), ex.Number)) throw;
                    retryCount++;
                    if (retryCount > MAX_RETRY) throw;
                    if (ex.Number == (int) RetryableSqlErrors.Timeout)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(5));
                    }
                    else
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(.5));
                    }
                }
            }
        }
    }
