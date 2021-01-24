    public class RemoteWatcher : IDisposable
    {
        private readonly DirectoryData[] _ddArray;
        private readonly Task[] _initializingTasks;
        public RemoteWatcher(string[] shares)
        {
            _ddArray = shares.Select(path =>
            {
                var dd = new DirectoryData();
                dd.Path = path;
                dd.Watcher = new FileSystemWatcher(path);
                dd.Watcher.EnableRaisingEvents = true;
                dd.Watcher.Created += (s, e) => OnChangedAsync(path);
                dd.Watcher.Renamed += (s, e) => OnChangedAsync(path);
                dd.Watcher.Changed += (s, e) => OnChangedAsync(path);
                dd.Watcher.Deleted += (s, e) => OnChangedAsync(path);
                dd.Watcher.Error += (s, e) => OnChangedAsync(path);
                dd.InProgress = true;
                return dd;
            }).ToArray();
            // Start processing all directories in parallel
            _initializingTasks = shares.Select(ProcessDirectoryAsync).ToArray();
        }
        private DirectoryData GetDirectoryData(string path)
        {
            return _ddArray.First(dd => dd.Path == path);
        }
        private async void OnChangedAsync(string path)
        {
            var dd = GetDirectoryData(path);
            Task delayTask;
            lock (dd)
            {
                dd.Cts?.Cancel();
                dd.Cts = new CancellationTokenSource();
                delayTask = Task.Delay(200, dd.Cts.Token);
            }
            try
            {
                // Workaround for changes firing twice
                await delayTask.ConfigureAwait(false);
            }
            catch (OperationCanceledException) // A new change occured
            {
                return; // Let the new event continue
            }
            lock (dd)
            {
                if (dd.InProgress)
                {
                    dd.HasChanged = true; // Let it finish and mark for restart
                    return;
                }
            }
            // Start processing
            var fireAndForget = ProcessDirectoryAsync(path);
        }
        private Task ProcessDirectoryAsync(string path)
        {
            return Task.Run(() =>
            {
                var dd = GetDirectoryData(path);
                var fileNames = Directory.EnumerateFiles(path).Select(Path.GetFileName);
                var hash = new HashSet<string>(fileNames, StringComparer.OrdinalIgnoreCase);
                lock (dd)
                {
                    dd.FileNames = hash; // It is backed by a volatile field
                    dd.InProgress = false;
                    if (dd.HasChanged)
                    {
                        dd.HasChanged = false;
                        var fireAndForget = ProcessDirectoryAsync(path); // Restart
                    }
                }
            });
        }
        public async Task<string[]> SearchAllAsync(params string[] fileNames)
        {
            await Task.WhenAll(_initializingTasks);
            return _ddArray.SelectMany(dd =>
                fileNames.Where(f => dd.FileNames.Contains(f))
                .Select(fileName => Path.Combine(dd.Path, fileName))
            ).ToArray();
        }
        public void Dispose()
        {
            foreach (var dd in _ddArray) dd.Watcher.Dispose();
        }
        private class DirectoryData
        {
            public string Path { get; set; }
            public FileSystemWatcher Watcher { get; set; }
            public bool HasChanged { get; set; }
            public bool InProgress { get; set; }
            private volatile HashSet<string> _fileNames;
            public HashSet<string> FileNames
            {
                get => _fileNames; set => _fileNames = value;
            }
            public CancellationTokenSource Cts { get; set; }
        }
    }
