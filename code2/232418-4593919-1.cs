    Task requestSomething(Action callback)
    {
        // do stuff...
        var task = Task.Factory.FromAsync(obj.BeginInvoke, obj.EndInvoke, ..., obj);
        task.ContinueWith(_ => callback());
        return task;
    }
    // usage:
    var tasks = Enumerable.Range(0, 5)
                          .Select(_ => requestSomething(singleCallback))
                          .ToArray();
    Task.WaitAll(tasks);
    mainCallback();
