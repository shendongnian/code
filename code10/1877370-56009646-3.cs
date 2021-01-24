    var task = Task.Run(() =>
    {
        using (Serilog.Context.LogContext.PushProperty("ExecutionScope", "MyMultithreadedScope "))
        using (var scope = app.ApplicationServices.CreateScope())
        {
            Logger.LogDebug("test");
            //....
        }
    });
