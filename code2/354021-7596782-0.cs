    public IEnumerable<string> GetAllFiles(string rootDirectory)
    {
        foreach(var directory in Directory.GetDirectories(
                                                rootDirectory, 
                                                "*", 
                                                SearchOption.AllDirectories))
        {
            foreach(var file in Directory.GetFiles(directory))
            {
                yield return file;
            }
        }
    }
