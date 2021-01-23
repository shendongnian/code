    private static void SetupFileSystemWatchers(string path, FileSystemEventHandler changedEventHandler)
    {
      if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
      {
        var watcher = new FileSystemWatcher(path);
        watcher.IncludeSubdirectories = false;
        watcher.Changed += changedEventHandler;
        watcher.EnableRaisingEvents = true;
        foreach (var subDirectory in Directory.GetDirectories(path))
        {
          SetupFileSystemWatchers(subDirectory, changedEventHandler);
        }
      }
