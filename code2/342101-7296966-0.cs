    public static List<string> CustomGetDirectories(string path,
        string searchPattern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly)
    {
        if (searchOption == SearchOption.TopDirectoryOnly)
            return Directory.GetDirectories(path, searchPattern).ToList();
        var directories = new List<string>(CustomGetDirectories(path, searchPattern));
        for (var i = 0; i < directories.Count; i++)
            directories.AddRange(CustomGetDirectories(directories[i], searchPattern));
        return directories;
    }
    public static List<string> CustomGetDirectories(string path, string searchPattern)
    {
        try
        {
            return Directory.GetDirectories(path, searchPattern).ToList();
        }
        catch (UnauthorizedAccessException)
        {
            return new List<string>();
        }
    }
