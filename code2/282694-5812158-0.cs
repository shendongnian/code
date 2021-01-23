    /* Presentation Layer */
    
    if (DAL.FileExists(binaryPath)
    {
        console.WriteLine("Do you wish to overwrite?");
        
        if (Console.ReadKey() == "Y") 
        {
            DAL.Save(binaryPath);  //proper classes in your dal etc here
        }
    }
    else 
    {
        DAL.Save(binaryPath);
    } 
    /* DAL */
    public bool FileExists(string path)
    {
        if (string.IsNullOrWhitespace(path)) return false;
        
        return File.Exists(path);
    }
    public void Save(string path)
    {
        WriteBinaryFile(frameCodes, path);
    }
