C#
    public static async Task<TResult[]> WhenAllFailFast<TResult>(
        params Task<TResult>[] tasks)
    {
        var taskList = tasks.ToList();
        while (taskList.Count > 0)
        {
            var task = await Task.WhenAny(taskList).ConfigureAwait(false);
            if(task.Exception != null)
            {
                // Left as an exercise for the reader: 
                // properly unwrap the AggregateException; 
                // handle the exception(s);
                // cancel the other running tasks.
                throw task.Exception.InnerException;           
            }
            taskList.Remove(task);
        }
        return await Task.WhenAll(tasks).ConfigureAwait(false);
     }
