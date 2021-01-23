    // TODO: Read up on FileSystemWatcher
    FileSystemWatcher watcher = new FileSystemWatcher();
    
    watcher.Path = @"C:\MyDirectory";
    watcher.Changed += new FileSystemEventHandler(watcher_Changed);
    watcher.Deleted += new FileSystemEventHandler(watcher_Deleted);
    watcher.Renamed += new RenamedEventHandler(watcher_Renamed)
    watcher.Created += new FileSystemEventHandler(watcher_Created);
    watcher.EnableRaisingEvents = true;
    watcher.Filter = "*.txt"; // could also set it to "text.txt" or "*"
    
    void watcher_Changed(object sender, System.IO.FileSystemEventArgs e))
    {
    	MessageBox.Show("Zomg " + e.FullPath +" has been changed!!");
    }
    private void fileWatcher_Renamed(object sender, System.IO.RenamedEventArgs e)
    {
    	MessageBox.Show(e.OldFullPath + " was renamed to " + e.FullPath);
    }
    private void fileWatcher_Deleted(object sender, System.IO.FileSystemEventArgs e)
    {
    	MessageBox.Show(e.FullPath + " was deleted!");
    }
    private void fileWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
    {
    	MessageBox.Show(e.FullPath + " was created!");
    }
