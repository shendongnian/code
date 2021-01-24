    private static void MonitorDirectory(string path)
            {
                FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
                fileSystemWatcher.Path = path;
                fileSystemWatcher.Created += FileSystemWatcher_Created;
                fileSystemWatcher.Renamed += FileSystemWatcher_Renamed;
                fileSystemWatcher.Deleted += FileSystemWatcher_Deleted;
                fileSystemWatcher.EnableRaisingEvents = true;
            }
