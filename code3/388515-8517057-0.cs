    private static void OnChanged(object source, FileSystemEventArgs e)
    {
        lock(MyLogger)
        {
            MyLogger.Log("something changed");
        }
    }
