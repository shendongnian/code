    var synchronizationContext = SynchronizationContext.Current;
    var task = Task.Factory.StartNew(...);
    task.ContinueWith(task =>
        synchronizationContext.Post(state => {
            if (!task.IsCanceled)
                task.Wait();
        }, null));
