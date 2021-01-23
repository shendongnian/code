    if(File.Exists(path)) 
    {
        // This path is a file
        ProcessFile(path); 
    }               
    else if(Directory.Exists(path)) 
    {
        // This path is a directory
        ProcessDirectory(path);
    }
    else 
    {
        Console.WriteLine("{0} is not a valid file or directory.", path);
    } 
