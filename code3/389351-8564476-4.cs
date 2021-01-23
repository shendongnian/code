    var synchronizationContext = SynchronizationContext.Current;
    var firstTask = Task.Factory.StartNew(...);
    var secondTask = firstTask.ContinueWith(...);
    var thirdTask = secondTask.ContinueWith(...);
    Task.Factory.ContinueWhenAll(
        new[] { firstTask, secondTask, thirdTask },
        tasks => synchronizationContext.Post(state =>
            Task.WaitAll(tasks.Where(task => !task.IsCanceled).ToArray()), null));
