    Task<B> resultTask = StartMyTask().ContinueWith<Task<B>>(task =>
    {
        var tcs = new TaskCompletionSource<B>();
        switch (task.Status)
        {
        case TaskStatus.Canceled:
            tcs.SetCanceled();
            break;
        case TaskStatus.Faulted:
            tcs.SetException(task.Exception);
            break;
        case TaskStatus.RanToCompletion:
            tcs.SetResult(Foo(task.Result));
            break;
        }
        return tcs.Task;
    }).Unwrap();
