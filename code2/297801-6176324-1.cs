    public static void ClearHiddenFlagIfNeeded(FileSystemInfo info)
    {
        if ((info.Attributes & FileAttributes.Hidden) != 0)
            info.Attributes &= ~FileAttributes.Hidden;
    }
    // startDir assumed to be full path
    public static void UnhideAll(string startDir)
    {
        DirectoryInfo dir = new DirectoryInfo(startDir);
        // First, clear the current directory
        ClearHiddenFlagIfNeeded(dir);
        // Second, recursively go into all sub directories
        foreach (var subDir in dir.GetDirectories())
            UnhideAll(subDir.FullName);
        // Third, fix all hidden files in this folder
        foreach (var file in dir.GetFiles())
            ClearHiddenFlagIfNeeded(file);
    }    
