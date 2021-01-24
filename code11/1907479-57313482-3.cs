C#
    public static async Task<TResult[]> WhenAllFailFast<TResult>(params Task<TResult>[] tasks)
    {
        var taskList = tasks.ToList();
        while (taskList.Count > 0)
        {
            var task = await Task.WhenAny(taskList).ConfigureAwait(false);
            if(task.Exception != null)
            {
                // TODO: handle the exception
                throw task.Exception.InnerException;           
            }
            taskList.Remove(task);
        }
        return await Task.WhenAll(tasks).ConfigureAwait(false);
     }
Note: this does not stop the other tasks from running to completion. 
