    void SomeMethod()
    {
        System.IO.FileSystemWatcher m_Watcher = new System.IO.FileSystemWatcher();
        m_Watcher.Path = path;
        m_Watcher.Filter = "*.*";
        m_Watcher.NotifyFilter = m_Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
        m_Watcher.Created += new FileSystemEventHandler(OnChanged);
        m_Watcher.EnableRaisingEvents = true;
    }
    private void OnChanged(object sender, FileSystemEventArgs e)
        {
            string path = e.FullPath;
            lock (listLock)
            {
                pathsToUpload.Add(e.FullPath);
            }
        }
