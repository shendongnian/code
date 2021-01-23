    public Task<string> SampleMethodAsync(string msg)
    {
        var tcs = new TaskCompletionSource<string>();
        longRunningIOOperationAsync().ContinueWith(task =>
        {
            tcs.SetResult(task.Result);
        });
        return tcs.Task;
    }
