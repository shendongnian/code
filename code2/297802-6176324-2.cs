    // startDir assumed to be full path
    public static void UnhideAll(string startDir)
    {
        DirectoryInfo dir = new DirectoryInfo(startDir);
        Console.WriteLine("Working in {0}", startDir);
        // First, clear hidden flag on the current directory (if needed)
        if ((dir.Attributes & FileAttributes.Hidden) != 0)
        {
            Console.WriteLine("Clearing hidden flag on dir");
            dir.Attributes &= ~FileAttributes.Hidden;
        }
        else
            Console.WriteLine("No need to clear flag since it's already non-hidden");
        // Second, recursively go into all sub directories
        foreach (var subDir in dir.GetDirectories())
            UnhideAll(subDir.FullName);
        // Third, fix all hidden files in the current folder
        foreach (var file in dir.GetFiles())
        {
            if ((file.Attributes & FileAttributes.Hidden) != 0)
            {
                Console.WriteLine("Clearing hidden flag on file {0}", file.FullName);
                file.Attributes &= ~FileAttributes.Hidden;
            }
            else
                Console.WriteLine("Skipping {0} since it's not hidden", file.FullName);
        }
    }    
