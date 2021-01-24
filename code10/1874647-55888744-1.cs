    var tasks = new[]
    {
        Task.FromResult(1),
        Task.FromException<int>(new ArgumentException("fail1")),
        Task.FromException<int>(new ArgumentException("fail2"))
    };
    var succeed = await RejectFailedFrom(tasks);
    // [ tasks[0] ]
