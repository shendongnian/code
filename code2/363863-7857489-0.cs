    public static void ProcessDirectory(string targetDirectory) 
    {
        foreach(string fileName in Directory.GetFiles(targetDirectory))
            ProcessFile(fileName);
        foreach(string subdirectory in Directory.GetDirectories(targetDirectory))
            ProcessDirectory(subdirectory);
			
		// Here is called for each directory and sub directory
    }
    public static void ProcessFile(string path) 
    {
	    // Here is called for each file in all subdirectories
    }
