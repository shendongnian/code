    public static async Task<TResult[]> WhenAllFailFast<TResult>(params Task<TResult>[] tasks)
    {
        var taskList = tasks.ToList();
        while (taskList.Count > 0)
        {
            var task = await Task.WhenAny(taskList).ConfigureAwait(false);
            taskList.Remove(task);
        }
        return await Task.WhenAll(tasks).ConfigureAwait(false);
     }
