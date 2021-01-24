    public static async Task IgnoreWhenCancelled(this Task task)
    {
        try
        {
            await task.ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
        }
    }
    public static async Task<T> IgnoreWhenCancelled<T>(this Task<T> task)
    {
        try
        {
            return await task.ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            return default;
        }
    }
