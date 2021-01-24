    private static SemaphoreSlim processCallsSemaphore = new SemaphoreSlim(1,1);
    // new SemaphoreSlim(1,1); => start with 1 count available and allow at max 1.
    public async Task ProcessCalls(string operation)
    {
        HttpContent next = new StringContent(operation);
        try
        {
            await processCallsSemaphore.WaitAsync();
            await PostURI(next);  // Assuming this is also an async API or can be made one.
        }
        finally
        {
            processCallsSemaphore.Release();
        }
    }
