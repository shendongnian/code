    Task requestSomething(Action callback)
    {
        // do stuff...
        return Task.Factory
                   .FromAsync(obj.BeginInvoke,
                              obj.EndInvoke,
                              ..., // async func arguments
                              obj)
                   .ContinueWith(_ => callback());
    }
    // usage:
    var tasks = Enumerable.Range(0, 5)
                          .Select(_ => requestSomething(singleCallback))
                          .ToArray();
    Task.WaitAll(tasks);
    mainCallback();
