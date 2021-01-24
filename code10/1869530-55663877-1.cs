    var semaphore = new SemaphoreSlim(1, 1);
    
    async Task ChangeState(bool state)
    {
        await semaphore.WaitAsync();
        try
        {
            await OutsideApi.ChangeState(state);
        }
        finally()
        {
            semaphore.Release();
        }
    }
    
    async Task DoStuff()
    {
        await semaphore.WaitAsync();
        try
        {
            await OutsideApi.DoStuff();
        }
        finally()
        {
            semaphore.Release();
        }
    }
