    public static void watchFiles(string path)
    {
        FileSystemWatcher watcher = new FileSystemWatcher();
        watcher.Path = path;
        watcher.Created += new FileSystemEventHandler(watcher_Handler);
        watcher.EnableRaisingEvents = true;
