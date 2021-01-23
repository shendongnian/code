    var newProfiler = new MiniProfiler("- Other task (discard this time)", ProfileLevel.Verbose);
    MiniProfiler.Current.AddProfilerResults(newProfiler);
    
    var asyncTask = new Task(() =>
    {
        using (newProfiler.Step("Async!"))
        {
            Thread.Sleep(500);
            using (newProfiler.Step("Async 2!"))
            {
                Thread.Sleep(1000);
            }
        }
    });
    
    asyncTask.Start();
