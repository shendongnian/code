    // How much deep to scan. (of course you can also pass it to the method)
    const int HowDeepToScan=4;
    
    public static void ProcessDir(string sourceDir, int recursionLvl) 
    {
      if (recursionLvl<=HowDeepToScan)
      {
        // Process the list of files found in the directory.
        string [] fileEntries = Directory.GetFiles(sourceDir);
        foreach(string fileName in fileEntries)
        {
           // do something with fileName
           Console.WriteLine(fileName);
        }
    
        // Recurse into subdirectories of this directory.
        string [] subdirEntries = Directory.GetDirectories(sourceDir);
        foreach(string subdir in subdirEntries)
           // Do not iterate through reparse points
           if ((File.GetAttributes(subdir) &
                FileAttributes.ReparsePoint) !=
                    FileAttributes.ReparsePoint)
    
                ProcessDir(subdir,recursionLvl+1);
      }
}
