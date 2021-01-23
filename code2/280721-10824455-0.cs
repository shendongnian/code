    private void PreLoadCachedSearches()
    {
        var worker = new BackgroundWorker() { WorkerReportsProgress = false, WorkerSupportsCancellation = true };
        worker.DoWork += new DoWorkEventHandler(DoWork);
        worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WorkerCompleted);
        worker.RunWorkerAsync(HttpContext.Current);
    }
    private static void DoWork(object sender, DoWorkEventArgs e)
    {
        HttpContext.Current = (HttpContext)e.Argument;
        var x = HttpContext.Current.Cache;
    }
    private static void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // Logging?
    }
