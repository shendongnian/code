    var watcher = new FileSystemWatcher(path, filter);
    watcher.Changed += (sender, e) => {
        FileStream file = null;
        try {
            Thread.Sleep(100); // hack for timing issues
            file = File.Open(
                e.FullPath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read
            );
        }
        catch(IOException) {
            // we couldn't open the file
            // this is probably because the copy operation is not done
            // just swallow the exception
            return;
        }
        // now we have a handle to the file
    };
