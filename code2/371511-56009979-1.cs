    private static void EnableFileWatcherLvl1(string folder, string fileName)
    {
        FileSystemWatcher watcher = new FileSystemWatcher();
        watcher.Path = folder;
        watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.Attributes;
        watcher.Filter = "*.txt";
        watcher.Changed += watcher_Changed;
        watcher.Deleted += watcher_Changed;
        watcher.EnableRaisingEvents = true;
    }
                    
    static void watcher_Changed(object sender, FileSystemEventArgs e)
    {            
        switch (e.ChangeType)
        {
            case WatcherChangeTypes.Changed: { // code here for created file }
                 break;
            case WatcherChangeTypes.Deleted: { // code here for deleted file }
                 break;
        }       
    }
