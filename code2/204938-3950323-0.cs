        private DirectoryEntry _iisServer = null;
        private DirectoryEntry iisServer
        {
            get
            {
                if (_iisServer == null)
                {
                    string path = string.Format("IIS://{0}/W3SVC/1", serverName);
                    _iisServer = new DirectoryEntry(path);
                }
                return _iisServer;
            }
        }
        private IDictionary<string, DirectoryEntry> _virtualDirectories = null;
        private IDictionary<string, DirectoryEntry> virtualDirectories
        {
            get
            {
                if (_virtualDirectories == null)
                {
                    _virtualDirectories = new Dictionary<string, DirectoryEntry>();
                    DirectoryEntry folderRoot = iisServer.Children.Find("Root", VirDirSchemaName);
                    foreach (DirectoryEntry virtualDirectory in folderRoot.Children)
                    {
                        _virtualDirectories.Add(virtualDirectory.Name, virtualDirectory);
                    }
                }
                return _virtualDirectories;
            }
        }
