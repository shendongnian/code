    public static async Task<CloudTable> EnsureTableIsEmpty(this CloudTable table)
    {
        await table.DeleteIfExistsAsync();
        await Policy
            .Handle<StorageException>((exc) => { return exc.Message == "Conflict"; })
            .WaitAndRetryAsync(
                5,
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                (exception, timeSpan, retryCount, context) =>
                {
                    //Logging stuff
                })
            .ExecuteAsync(() => table.CreateIfNotExistsAsync());
        
        return table;
    }
