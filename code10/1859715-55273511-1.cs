    public sealed class FileSystemWatcherManager : IDisposable
    {
        private bool _disposed = false;
        private readonly Dictionary<string, FileSystemWatcher> _watchers;
        public delegate void ChangedDetected(FileSystemEventArgs args);
        public event ChangedDetected OnChangedDetected;
        public FileSystemWatcherManager()
        {
            _watchers = new Dictionary<string, FileSystemWatcher>();
        }
        ~FileSystemWatcherManager()
        {
            Dispose(false);
        }
        public FileSystemWatcher RegisterWatcher(string directoryPath, string filter = "*", FileSystemEventHandler customChangeEvent = null)
        {
            if (Directory.Exists(directoryPath))
            {
                if (!_watchers.ContainsKey(directoryPath))
                {
                    var watcher = new FileSystemWatcher(directoryPath, filter)
                    {
                        EnableRaisingEvents = true,
                        IncludeSubdirectories = true
                    };
                    watcher.NotifyFilter =  NotifyFilters.Attributes |
                                            NotifyFilters.CreationTime |
                                            NotifyFilters.FileName |
                                            NotifyFilters.LastAccess |
                                            NotifyFilters.LastWrite |
                                            NotifyFilters.Size |
                                            NotifyFilters.Security;
                    if (customChangeEvent != null)
                        watcher.Changed += customChangeEvent;
                    else
                        watcher.Changed += Watcher_Changed;
                    _watchers.Add(directoryPath, watcher);
                }
            }
            else
            {
                throw new InvalidOperationException($"Invalid Directory: {directoryPath}");
            }
            return _watchers.TryGetValue(directoryPath, out FileSystemWatcher value) ? value : null;
        }
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            OnChangedDetected?.Invoke(e);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                if (disposing)
                {
                    foreach(KeyValuePair<string,FileSystemWatcher> pair in _watchers)
                    {
                        pair.Value.Dispose();                       
                    }
                    _watchers.Clear();
                }
                _disposed = true;
            }
        }
    }
