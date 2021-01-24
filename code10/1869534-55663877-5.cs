    var readerWriterLock = new AsyncReaderWriterLock();
    
    async void ChangeState(bool state)
    {
        using(await readerWriterLock.WriterLockAsync())
        {
            await OutsideApi.ChangeState(state);
        }
    }
    
    async void DoStuff()
    {
        using(await readerWriterLock.WriterLockAsync())
        {
            await OutsideApi.DoStuff();
        }
    }
