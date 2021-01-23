    public bool IsDirectory(string directory)
    {
        if(directory == null)
        {
            throw new ArgumentOutOfRangeException(); // or however you want to handle null values
        }
        else if(System.IO.Path.GetExtension(directory) == string.Empty)  // returns string.Empty when no extension found
        {
            return true;
        }
        else
        {
            return false; // extension found, therefore it's a file
        }
    }
