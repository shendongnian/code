    void watcher_Created(object sender, FileSystemEventArgs e)
    {
        Action action = () => Text = e.Name + " " + e.ChangeType;
        // Or Dispatcher.Invoke - it depends on your application type
        Invoke(action);
    }
