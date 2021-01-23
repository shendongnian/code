    private readonly object _syncObject = new object();
    private bool TryUpdate(object someData)
    {
        if (Monitor.TryEnter(_syncObject))
        {
            try
            {
                //Update the data here.
                return true;
            }
            finally
            {
                Monitor.Exit(_SyncObject);
            }
        }
        return false;
    }
