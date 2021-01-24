    public static int ProcessFile(string path)
    {
        return File.ReadAllLines(path).Length;
    }
**2. Then process the directories recursively. Call the above method for all files, recursively call itself for more directories**
    public static int ProcessDirectory(string targetDirectory)
    {
        int totalLines = 0;
        // Process the list of files found in the directory.
        string[] fileEntries = Directory.GetFiles(targetDirectory);
        foreach (string fileName in fileEntries)
            totalLines += ProcessFile(fileName);
        // Recurse into subdirectories of this directory.
        string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
        foreach (string subdirectory in subdirectoryEntries)
            totalLines += ProcessDirectory(subdirectory);
        return totalLines;
    }
In your main function, you can start the call with 
    ProcessDirectory(Environment.CurrentDirectory);
