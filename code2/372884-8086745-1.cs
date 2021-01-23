    public bool IsDirectory(string directory)
    {
        if(directory == null)
        {
            throw new ArgumentNullException(); // or however you want to handle null values
        }
        
        // GetExtension(string) returns string.Empty when no extension found
        return System.IO.Path.GetExtension(directory) == string.Empty;
    }
