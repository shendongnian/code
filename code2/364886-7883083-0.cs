    public static void LogExceptions(this Task task)
    {
        task.ContinueWith( t =>
        {
             var aggException = t.Exception.Flatten();
             foreach(var exception in aggException.InnerExceptions)
                 LogException(exception);
        }, 
        TaskContinuationOptions.OnlyOnFaulted);
    }
