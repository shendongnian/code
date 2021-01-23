    protected override IAsyncResult BeginTrack(TrackingRecord record, TimeSpan timeout, AsyncCallback callback, object state)
    {
        Task result = Task.Factory.StartNew(
            (taskState) =>
            {
               // ... your async work here ...
            },
            state);
        if(callback != null)
        {
            result.ContinueWith((t) => callback(t));
        }
        return result;
    }
    protected override void EndTrack(IAsyncResult asyncResult)
    {
       // Call wait to block until task is complete and/or cause any exceptions that occurred to propagate to the caller
       ((Task)asyncResult).Wait();
    }
