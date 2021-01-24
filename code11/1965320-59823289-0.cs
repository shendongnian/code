    public Task<T> DoSomeWorkAsync()
    {
        TaskCompletionSource<T> completionSource = new TaskCompletionSource<T>();
        SomeBackgroundWorker worker = new SomeBackgroundWorker();
        worker.OnWorkComplete += workComplete;
        worker.DoSomeWorkInABackgroundThread();
        return completionSource.Task;
        void workComplete(T workResult)
        {
            worker.OnWorkComplete -= workComplete;
            completionSource.SetResult(workResult);
        }
    }
