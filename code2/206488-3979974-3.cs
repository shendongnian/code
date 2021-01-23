    protected override void OnStart(string[] args)
    {
        try
        {
            _keys.AddRange(new string[] { "csv", "xml", "zip", "rivx" });
            _watcher = new FileSystemWatcher(AppSettings.Default.FTPRootPath, "*.*");
            _watcher.IncludeSubdirectories = true;
            _watcher.NotifyFilter = sysIO.NotifyFilters.DirectoryName | sysIO.NotifyFilters.FileName | sysIO.NotifyFilters.LastAccess | sysIO.NotifyFilters.CreationTime | sysIO.NotifyFilters.LastWrite;
            _watcher.Created += new sysIO.FileSystemEventHandler(fileCreatedOrChanged);
            _watcher.Changed += new sysIO.FileSystemEventHandler(fileCreatedOrChanged);
            _watcher.EnableRaisingEvents = true;
            WriteToEventLog("Exit Start", EventLogEntryType.Information);
        }
