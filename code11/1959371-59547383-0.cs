    public static Thread CreateAwaitableThread(Action action, out Task threadCompletion)
    {
        var tcs = new TaskCompletionSource<bool>();
        threadCompletion = tcs.Task;
        return new Thread(() =>
        {
            try
            {
                action();
            }
            finally
            {
                tcs.SetResult(true);
            }
        });
    }
