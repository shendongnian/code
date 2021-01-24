    private static SemaphoreSlim sem = new SemaphoreSlim(1);
    private static async Task SaveAsync()
    {
       if(await sem.WaitAsync(TimeSpan.FromSeconds(1))) // Can be pimped with cancel token
       {
            try
            {
                Logging.Info(" writing bitmex data to database");
                await SomelenghthyDbUpdate1.ConfigureAwait(false);
                await SomelenghthyDbUpdate2.ConfigureAwait(false);
                await SomelenghthyDbUpdate3.ConfigureAwait(false);
                await SomelenghthyDbUpdate4.ConfigureAwait(false);
            }
            finally
            {
                sem.Release();
            }
        }
    }
