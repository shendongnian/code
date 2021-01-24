    static async Task Main(string[] args)
    {
        var jobs = new List<Func<Task<int>>>
        {
            DownloadDelay15,
            DownloadDelay2,
            async () => { await Task.Delay(1000); return 6; }
        };
        var tasks = jobs.Select(job => job()).ToList();
        var watch = Stopwatch.StartNew();
        var results = await Task.WhenAll(tasks);
        watch.Stop();
        var elapsedSeconds = watch.Elapsed.Seconds;
    }
