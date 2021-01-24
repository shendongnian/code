    public static void CreateDirectoryNextToFileType(string rootPath, string fileExtension, 
        string newDirectoryName)
    {
        if (rootPath == null || !Directory.Exists(rootPath))
            throw new ArgumentException("rootPath must be the path to an existing directory");
        if (fileExtension == null) throw new ArgumentNullException(nameof(fileExtension));
        if (string.IsNullOrEmpty(subDirectoryName) ||
            subDirectoryName.Any(chr => Path.GetInvalidPathChars().Contains(chr)))
            throw new ArgumentException("subDirectoryName is null, empty, or " + 
                "contains invalid characters");
        // Enumerate all directories and return those that 
        // contain a file with the specified extension
        var directoriesContainingFile = new DirectoryInfo(rootPath)
            .EnumerateDirectories("*", SearchOption.AllDirectories)
            .Where(dir => dir.EnumerateFiles().Any(file =>
                file.Extension.Equals(fileExtension, StringComparison.OrdinalIgnoreCase)));
        // For each of the directories, create a sub directory with the specified name
        foreach (var directory in directoriesContainingFile)
        {
            directory.CreateSubdirectory(newDirectoryName);
        }
    }
