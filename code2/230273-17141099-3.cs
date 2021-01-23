    private static FileSystemWatcher watcher;
    public static void watchFiles(string path)
    {
        if (watcher != null)
        {
            watcher.EnableRaisingEvents = false;
            watcher.Created -= new FileSystemEventHandler(watcher_Handler);
        }
        watcher = new FileSystemWatcher();
        watcher.Path = path;
        watcher.Created += new FileSystemEventHandler(watcher_Handler);
        watcher.EnableRaisingEvents = true;
    }
