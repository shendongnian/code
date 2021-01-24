    public static async Task Main()
    {
        var oldPath = "foo"; // folder to copy
        var newPath = "dummy"; // folder to create dummies
        var oldDirectory = Path.GetFullPath(oldPath);
        var oldDirectoryParent = Path.GetDirectoryName(oldDirectory);
        var newDirectory = Path.Combine(oldDirectoryParent, newPath);
        Directory.CreateDirectory(newDirectory);
        var paths = Directory.EnumerateFileSystemEntries(oldDirectory, "*.*", SearchOption.AllDirectories);
        var filesAndFolders = paths.ToLookup(Directory.Exists);
        var directoryTasks = filesAndFolders[true]
            .Select(path => newDirectory + path.Substring(oldDirectory.Length))
            .Select(CreateDirectoryAsync);
        await Task.WhenAll(directoryTasks);
        var fileTasks = filesAndFolders[false]
            .Select(path => newDirectory + path.Substring(oldDirectory.Length))
            .Select(CreateAsync);
        await Task.WhenAll(fileTasks);
    }
    public static Task<FileStream> CreateAsync(string path) => Task.Run(() => File.Create(path));
    public static Task<DirectoryInfo> CreateDirectoryAsync(string path) => Task.Run(() => Directory.CreateDirectory(path));
