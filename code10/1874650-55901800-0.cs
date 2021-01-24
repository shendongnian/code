    var cts = new CancellationTokenSource();
    cts.Cancel();
    var canceled = Task.Run(() => 1, cts.Token);
    var faulted = Task.FromException<int>(new Exception("Some Exception"));
    var ranToCompletion = Task.FromResult(1);
    var allTasks = new[] { canceled, faulted, ranToCompletion };
    // wait all tasks to complete regardless anything
    Task.WhenAll(allTasks).ContinueWith(_ => { }).Wait();
    foreach(var t in allTasks)
    {
        Console.WriteLine($"Task #{t.Id} {t.Status}");
        if (t.Status == TaskStatus.Faulted)
            foreach (var e in t.Exception.InnerExceptions)
                Console.WriteLine($"\t{e.Message}");
        if (t.Status == TaskStatus.RanToCompletion)
            Console.WriteLine($"\tResult: {t.Result}");
    }
