    public static Task SendASync(this AwaitEnabledThread thread, SendOrPostCallback d, object state = null)
    {
        var tcs = new TaskCompletionSource<object>();
        thread.Post(s =>
        {
            try
            {
                // execute the delegate
                d(state);
                // return to the previous SynchronizationContext
                tcs.SetResult(null);
            }
            catch (Exception exception)
            {
                // return to the previous SynchronizationContext
                tcs.SetException(exception);
            }
        }, tcs);
        return tcs.Task;
    }
