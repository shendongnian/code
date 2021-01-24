        public FolderWatcher(string watchedFolderPath)
        {
            _watcher = new FileSystemWatcher(watchedFolderPath);
            _watcher.Created += (sender, args) =>
            {
                if (this.Created != null)
                {
                    this.Created(sender, args);
                }
            };
            _watcher.Changed += (sender, args) =>
            {
                if (this.Changed != null)
                {
                    this.Changed(sender, args);
                }
            };
            _watcher.EnableRaisingEvents = true;
        }
