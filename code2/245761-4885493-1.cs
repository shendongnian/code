    protected override void OnStart(string[] args)
    {
        watcher = new FileSystemWatcher();
        watcher.Path = @"C:\temp\services\Watched";
        watcher.Changed += new FileSystemEventHandler(LogFileSystemChanges);
        watcher.Created += new FileSystemEventHandler(LogFileSystemChanges);
        watcher.Deleted += new FileSystemEventHandler(LogFileSystemChanges);
        watcher.Renamed += new RenamedEventHandler(LogFileSystemRenaming);
        watcher.Error += new ErrorEventHandler(LogBufferError);
        watcher.EnableRaisingEvents = true;
        LogEntry("Monitoring Started.");
    }
    protected override void OnStop()
    {
        watcher.EnableRaisingEvents = false;
        watcher.Dispose();
        LogEntry("Monitoring Stopped.");
    }
    private object lockObject = new Object();
    void LogEntry(string message)
    {
        lock (lockObject)
        {
            counter++;
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(counter + ". " + message);
            }
        }
    }
