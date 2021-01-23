    foreach (string sRelativePath in dicFiles.Keys)
    {
        string sFullPath = Path.Combine(sDefaultLocation, sRelativePath);
        string sDirectory = Path.GetDirectoryName(sFullPath);
        
        if (!Directory.Exists(sDirectory))
        {
            Directory.CreateDirectory(sDirectory);
        }
    
        saveFile(sFullPath, dicFiles[sRelativePath]);
    }
