    public IEnumerable<string> GetFiles(string basePath, params string[] searchPatterns)
    {
        foreach(var searchPattern in searchPatterns)
        {
            foreach(var file in Directory.GetFiles(basePath, searchPattern))
            {
                    yield return file;    
            }
        }
    }
