    public IEnumerable<string> GetFiles(
         string basePath, 
         params string[] searchPatterns)
    {
        if (searchPatterns == null || searchPatterns.Length == 0)
        {
            return Directory.GetFiles(basePath);
        }
        return Enumerable.SelectMany(searchPatterns, 
                             p => Directory.GetFiles(basePath, p));
    }
