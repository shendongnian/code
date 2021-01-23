    private BackgroundWorker _bg;
    public FileProcessor(BackgroundWorker bg)
    {
       _bg = bg;
    }
    public void ProcessFiles(Files files)
    {
        // Process files
        // ...
        // Report Progress
        _bg.ReportProgress(e.FileProcessedCount, e);
    }
