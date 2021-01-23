    private bool _fileExists = true;
    
    public void Process(string pathToOriginalFile, string pathToCopy)
    {
        File.Copy(pathToOriginalFile, pathToCopy);
        
        FileSystemWatcher watcher = new FileSystemWatcher();
        watcher.Path = pathToOriginalFile;
        watcher.Deleted += new FileSystemEventHandler(OnFileDeleted);
        
        bool doneProcessing = false;
        watcher.EnableRaisingEvents = true;
        while(_fileExists && !doneProcessing)
        {
            // process the copy here
        }
        
        ...
    }
    
    private void OnFileDeleted(object source, FileSystemEventArgs e)
    {
        _fileExists = false;
    }
