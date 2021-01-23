    static void StartMailTasks(string[] addresses)
    {
        List<Task> tasks = new List<Task>();
        foreach (var address in addresses)
        {
            tasks.Add(Task.Factory.StartNew(Email, address));
        }
    
        Task.Factory.ContinueWhenAll(tasks.ToArray(), AllDone, TaskContinuationOptions.OnlyOnRanToCompletion);
        Task.Factory.ContinueWhenAny(tasks.ToArray(), ReportError, TaskContinuationOptions.OnlyOnFaulted);
    }
    
    static void AllDone(Task[] tasks)
    {
        // All is well
    }
    
    static void ReportError(Task errorTask)
    {
        // Log or report the error
    }
    
    static void Email(object state )
    {
        // send the e-mail  
        // Can throw error, if needed
    }
