    static string[] FindFiles(string path)
    {
        string directory = Path.GetDirectoryName(path); // seperate directory i.e. ..\ThirdParty\dlls
        string filePattern = Path.GetFileName(path); // seperate file pattern i.e. *.dll
        // if path only contains pattern then use current directory
        if (String.IsNullOrEmpty(directory))
            directory = Directory.GetCurrentDirectory();
        
        directory = Path.GetFullPath(directory); // convert relative path to absolute i.e. c:\xyz\ThirdParty\dlls
        if (!Directory.Exists(directory))      
            return new string[0];
        
        var files = Directory.GetFiles(directory, filePattern); 
        return files;
    }
