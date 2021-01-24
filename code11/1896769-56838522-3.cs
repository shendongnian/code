    public static async Task<TResult[]> WhenAllWithDelay<TResult>(
        IEnumerable<Task<TResult>> tasks, int delay)
    {
        var tasksList = new List<Task<TResult>>();
        foreach (var task in tasks)
        {
            await Task.Delay(delay).ConfigureAwait(false);
            tasksList.Add(task);
        }
        return await Task.WhenAll(tasksList).ConfigureAwait(false);
    }
