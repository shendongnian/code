    private string[] extensions = { ".css", ".less", ".cshtml", ".js" };
    private void WatcherOnChanged(object sender, FileSystemEventArgs fileSystemEventArgs)
    {
        var ext = (Path.GetExtension(fileSystemEventArgs.FullPath) ?? string.Empty).ToLower();
        if (extensions.Any(ext.Equals))
        {
            // Do your magic here
        }
    }
