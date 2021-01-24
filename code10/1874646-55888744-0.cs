    public async Task<Task[]> RejectFailedFrom(params Task[] tasks)
    {
        try
        {
            await Task.WhenAll(tasks);
        }
        catch(Exception exception)
        {
            // Handle failed tasks maybe
        }
        return tasks.Where(task => task.Status == TaskStatus.RanToCompletion).ToArray();
    }
