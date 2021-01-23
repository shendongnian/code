    public IAsyncResult BeginSomeLongRunningOperation(string sampleParam, AsyncCallback callback, object asyncState)
    {
        Task<int> processingTask = Task<int>.Factory.StartNew(
            _ =>
            {
                 ... perform insanely long running operation here ...
             
                 return 42;    
            },
            asyncState);
        // If there was a callback, we have to invoke it after the processing finishes
        if(callback != null)
        {
            processingTask.ContinueWith(
                _ =>
                {
                    callback(calculationTask);                   
                },
                TaskContinuationOptions.ExecuteSynchronously);
        }
        return processingTask;
    }
    public int EndSomeLongRunningOperation(IAsyncResult asyncResult)
    {
        return ((Task<int>)asyncResult).Result;
    }
