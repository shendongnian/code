    public void RefreshData(object state = null /* for direct calls */)
    {
        if (SyncContext != SynchronizationContext.Current)
        {
            SyncContext.Post(RefreshData, null); // SendOrPostCallback
            return;
        }
        // ...
    }
