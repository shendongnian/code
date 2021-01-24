    using NeoSmart.AsyncLock;
    // ...
    private static AsyncLock driverlock = new AsyncLock();
    using (driverlock.Lock())
    {
        // https://stackoverflow.com/questions/58665122/stop-driver-process-after-session-not-created-this-version-of-chromedriver-on
        var process = Process.GetProcessesByName("chromedriver");
        try
        {
            Browser = new ChromeDriver(chromeOptions);
        }
        catch(InvalidOperationException e)
        {
            var newProcess = Process.GetProcessesByName("chromedriver");
            newProcess.Select(x => x.Id)
                .Except(process.Select(x => x.Id))
                .ToList().ForEach(x => Process.GetProcessById(x).Kill());
            throw;
        }
    }
