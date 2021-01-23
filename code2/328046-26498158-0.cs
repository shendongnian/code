    public class Files
    {
         public static FileSystemWatcher WatchForChanges(string path, string filter, Action triggeredAction)
                {
                    var monitor = new FileSystemWatcher(path, filter);
        
                    //monitor.NotifyFilter = NotifyFilters.FileName;
                    monitor.Changed += (o, e) => triggeredAction.Invoke();
                    monitor.Created += (o, e) => triggeredAction.Invoke();
                    monitor.Renamed += (o, e) => triggeredAction.Invoke();
                    monitor.EnableRaisingEvents = true;
        
                    return monitor;
                }
    }
