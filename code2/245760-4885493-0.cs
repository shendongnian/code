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
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(counter + ". " + message);
            }
        }
    }
