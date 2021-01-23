    public static void Main()
    {
        var fileSystemWatcher = new FileSystemWatcher("C:\\Temp", "*.*");
        fileSystemWatcher.NotifyFilter = NotifyFilters.Security;
        fileSystemWatcher.Changed += fileSystemWatcher_Changed;
        fileSystemWatcher.EnableRaisingEvents = true;
        Thread.Sleep(-1);
    }
    private static void fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
    {
    }
