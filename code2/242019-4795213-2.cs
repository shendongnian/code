    System.Collections.Generic.List<string> filesList = new System.Collections.Generic.List<string>();
    string path = @"c:\my\directory\";
    
    if (System.IO.Directory.Exists(path))
    {
        //Get files for the base path
        string[] baseDirectoryFiles = System.IO.Directory.GetFiles(path);
        filesList.AddRange(baseDirectoryFiles);
    
        // Get files in subdirectories (first level) of base path
        foreach (string directory in System.IO.Directory.GetDirectories(path))
        {
            string[] directoryFiles = System.IO.Directory.GetFiles(directory);
            filesList.AddRange(directoryFiles);
        }
    
        string[] filesArray = filesList.ToArray();
    }
    else
    {
        //Your directory was not found on the filesystem
        //handle as appropriate
    }
