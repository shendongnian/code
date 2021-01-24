    async Task ChangeState(bool state)
    {
        await Task.Yield();
    
        doStuffLock.EnterWriteLock();
    
        try
        {
            changeStateLock.EnterReadLock();
    
            try
            {
                await OutsideApi.ChangeState(state);
            }
            finally
            {
                changeStateLock.ExitReadLock();
            }
        }
        finally
        {
            doStuffLock.ExitWriteLock();
        }
    }
    
    async Task DoStuff()
    {
        await Task.Yield();
    
        changeStateLock.EnterWriteLock();
    
        try
        {
            doStuffLock.EnterReadLock();
    
            try
            {
                await OutsideApi.DoStuff();
            }
            finally
            {
                doStuffLock.ExitReadLock();
            }
        }
        finally
        {
            changeStateLock.ExitWriteLock();
        }
    }
