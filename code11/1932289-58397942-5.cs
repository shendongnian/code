    private static SingleThreadTaskScheduler stts = new SingleThreadTaskScheduler();
    public static Task<TResult> DBCall<TResult>(Func<TResult> function)
    {
        return Task.Factory.StartNew(() =>
        {
            return function();
        }, CancellationToken.None, TaskCreationOptions.None, stts);
    }
