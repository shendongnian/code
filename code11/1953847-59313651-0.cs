        public FolderWatcher(string watchedFolderPath)
        {
            _watcher = new FileSystemWatcher(watchedFolderPath);
            _watcher.Created += (sender, args) => this.Created(sender, args);
            _watcher.Changed += (sender, args) => this.Changed(sender, args);
            _watcher.EnableRaisingEvents = true;
        }
