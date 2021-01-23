    private readonly Result theResult = new Result();
    public override Task<Result> StartSomeTask()
    {
        var taskSource = new TaskCompletionSource<Result>();
        taskSource.SetResult(theResult);
        return taskSource.Task;
    }
