    // startDir assumed to be full path
    public static void UnhideAll(string startDir)
    {
        DirectoryInfo dir = new DirectoryInfo(startDir);
        // First, clear the current directory
        dir.Attributes &= ~FileAttributes.Hidden;
        // Second, recursively go into all sub directories
        foreach (var subDir in dir.GetDirectories())
            UnhideAll(subDir.FullName);
        // Third, fix all hidden files in this folder
        foreach (var file in dir.GetFiles())
            file.Attributes &= ~FileAttributes.Hidden;
    }    
