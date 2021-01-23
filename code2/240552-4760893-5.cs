    public void TaskStartMethod()
    {
        ThradPool.QueueUserWorkItem(o=>
        {
            // Perform the task
            
            // Call the method when the task is complete
            OnTaskComplete(new Result(...));
        });
    }
