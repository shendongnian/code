    public static void OnChanged(object source, FileSystemEventArgs e)
    {
        Console.WriteLine("File has been changed.");
        var watcher = source as FileSystemWatcher;
        if (watcher != null)
        {
            watcher.EnableRaisingEvents = false;
        }
        else
        {
            // Hmm... some other object called this method.
            // Do you really want that to be allowed?
        }
    }
