    public static async Task<TaskStatus> HideCancellationException(this Task task)
    {
        try
        {
            await task;
            return task.Status;
        }
        catch (OperationCanceledException)
        {
            return TaskStatus.Canceled;
        }
    }
