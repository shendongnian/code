    public delegate void OnTaskCompleteDelegate(Result someResult);
    public void TaskStartMethod()
    {
        OnTaskCompleteDelegate callback = new OnTaskCompleteDelegate(OnTaskComplete);
        ThradPool.QueueUserWorkItem(o=>
        {
            // Perform the task
            
            // Use the callback to notify that the
            // task is complete. You can send a result
            // or whatever you find necessary.
            callback(new Result(...));
        });
    
    }
    
    public void OnTaskComplete(Result someResult)
    {
        // Process the result
    }
