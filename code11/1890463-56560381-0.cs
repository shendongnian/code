    public static void OnExceptionLogError(this Task task, string message)
    {
        task.ContinueWith(t =>
        {
            // Log t.Exception
        }, TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously);
    }
