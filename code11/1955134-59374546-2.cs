    public static async Task<bool> WaitFor(Task task, TimeSpan timeout, Action<Exception> handleException)
    {
        var wrapperTask = task.ContinueWith(
            t => handleException(t.Exception.InnerException), 
            TaskContinuationOptions.OnlyOnFaulted);
        
        return await Task.WhenAny(wrapperTask, Task.Delay(timeout)) == task;
    }
