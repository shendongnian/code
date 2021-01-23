    System.Collections.Generic.List<string> filesList = new System.Collections.Generic.List<string>();
    string path = @"c:\my\directory\";
    
    foreach (string directory in System.IO.Directory.GetDirectories(path))
    {
        foreach (string file in System.IO.Directory.GetFiles(directory))
        {
            filesList.Add(file);
        }
    }
    
    string[] filesArray = filesList.ToArray();
