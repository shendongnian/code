    var tasks = urls
        .Select(url => Task.Factory.StartNew(() => processUrl(url)))
        .ToArray();
    Task.WaitAll(tasks);
    var restuls = tasks.Select(arg => arg.Result).ToList();
