    string[] filters = { "*.txt", "*.doc", "*.docx", "*.xls", "*.xlsx" };
    List<FileSystemWatcher> watchers = new List<FileSystemWatcher>();
    
    foreach(string f in filters)
    {
        FileSystemWatcher w = new FileSystemWatcher();
        w.Filter = f;
        w.Changed += MyChangedHandler;
        watchers.Add(w);
    }
