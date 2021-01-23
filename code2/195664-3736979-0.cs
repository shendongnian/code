    public static void OnChanged(object source, FileSystemEventArgs e)
    {
       FileSystemWatcher watcher = (FileSystemWatcher)source;
       watcher.EnableRaisingEvents = false ;
    }
