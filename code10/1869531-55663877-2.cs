    var readerWriterLock = new AsyncReaderWriterLock();
    
    async Task ChangeState(bool state)
    {
        using(await readerWriterLock.WriterLockAsync())
        {
            await OutsideApi.ChangeState(state);
        }
    }
    
    async Task DoStuff()
    {
        using(await readerWriterLock.WriterLockAsync())
        {
            await OutsideApi.DoStuff();
        }
    }
