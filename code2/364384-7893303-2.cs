    public static Task ContinueWithIf(this Task task, Func<bool> predicate, Action<Task> continuation, TaskScheduler scheduler)
    {
        var tcs = new TaskCompletionSource<object>(); 
        task.ContinueWith( t =>
        {
            if (predicate())
            {
                new TaskFactory(scheduler).StartNew( 
                    () => 
                    {
                        continuation(task); 
                        tcs.SetResult(null); 
                    });
            }
            else
            {
                tcs.TrySetCanceled();
            }
        });
        return tcs.Task;
    }
