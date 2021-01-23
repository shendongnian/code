    public static async Task<bool> BeforeTimeout(this Task task, int millisecondsTimeout)
    {
        if (task.IsCompleted || millisecondsTimeout == Timeout.Infinite) return true;
        if (millisecondsTimeout == 0) return false;
        var tcs = new TaskCompletionSource<object>();
        using (var timer = new Timer(state => ((TaskCompletionSource<object>)state).TrySetCanceled(), tcs,
            millisecondsTimeout, Timeout.Infinite))
        {
            return await Task.WhenAny(task, tcs.Task) == task;
        }
    }
