    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    try
    {
        string pathToFile = Path.Combine(desktopPath, "Hackers.avi");
        if (File.Exists(pathToFile))
        {
            File.Delete(pathToFile);
        }
    }
    // etc...
