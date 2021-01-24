    public IEnumerable<string> AccessFile(string pathName)
    {
        if (string.IsNullOrEmpty(pathName) || !IsValidFileName(pathName))
        {
            throw new ApplicationException("Invalid Path Name");
        }
        try
        {
            var result = File.ReadAllLines(pathName);
            return result;
        }
        catch (IOException ex)
        {
            throw new ApplicationException("Error Accessing File", ex);
        }
    }
