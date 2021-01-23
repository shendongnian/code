    string[] desiredExtensions = new [] { ".html", ... };
    string desiredExtension = ".html";
    watcher.Changed += watcher_Changed;
    ...
    private void watcher_Changed(object sender, FileSystemEventArgs e)
    {
       // single
       if (string.Equals(Path.GetExtension(e.FullPath), desiredExtension, StringComparison.CurrentCultureIgnoreCase))
       { ... }
       // several
       if (desiredExtensions.Any(ext => string.Equals(Path.GetExtension(e.FullPath), ext, StringComparison.CurrentCultureIgnoreCase)))
       { ... }
    }
    
