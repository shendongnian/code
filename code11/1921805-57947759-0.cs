private ReaderWriterLock _lock;
public void LoadData()
{
    _lock.AcquireWriterLock();
    try
    {
         // Do some work ..... Loading from files.
    }
    finally
    {
        _lock.ReleaseWriterLock()
    }
}
public IDictionary GetData(string key1, string key2)
{
    _lock.AcquireReaderLock();
    try
    {
        //Do something....
        return data;
    }
    finally
    {
        _lock.ReleaseReaderLock()
    }
}
