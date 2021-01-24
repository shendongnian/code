    public void Cancel() => ...;
    public async ValueTask DisposeAsync()
    {
        // Cancel();
        await Task.WhenAll(_runningTasks.ToArray());
    }
