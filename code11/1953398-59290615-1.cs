    public static int GetTotalLinesInAllFiles(string targetDirectory)
    {
        int totalLines = 0;
        // Process the list of files found in the directory.
        foreach (string fileName in Directory.GetFiles(targetDirectory))
            totalLines += File.ReadAllLines(fileName).Length;
        // Recurse into subdirectories of this directory.
        foreach (string subdirectory in Directory.GetDirectories(targetDirectory))
            totalLines += GetTotalLinesInAllFiles(subdirectory);
        return totalLines;
    }
In your main function, you can start the call with 
    ProcessDirectory(Environment.CurrentDirectory);
