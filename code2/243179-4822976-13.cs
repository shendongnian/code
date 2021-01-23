    private const int MAX_RETRY = 2;
    private const double LONG_WAIT_SECONDS = 5;
    private const double SHORT_WAIT_SECONDS = 0.5;
    private static readonly TimeSpan longWait = TimeSpan.FromSeconds(LONG_WAIT_SECONDS);
    private static readonly TimeSpan shortWait = TimeSpan.FromSeconds(SHORT_WAIT_SECONDS);
    private enum RetryableSqlErrors
    {
        Timeout = -2,
        NoLock = 1204,
        Deadlock = 1205,
        WordbreakerTimeout = 30053,
    }
    private void Retry<T>(Action<T> retryAction) where T : DataContext, new()
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
                    when (ex.Number == (int) RetryableSqlErrors.Timeout &&
                          retryCount < MAX_RETRY)
                {
                    Thread.Sleep(longWait);
                }
                catch (SqlException ex)
                    when (Enum.IsDefined(typeof(RetryableSqlErrors), ex.Number) &&
                          retryCount < MAX_RETRY)
                {
                    Thread.Sleep(shortWait);
                }
                retryCount++;
            }
        }
    }
