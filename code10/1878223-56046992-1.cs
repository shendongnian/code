    static IEnumerable<FileSystemInfo> GetFileSystemObjects(DirectoryInfo dirInfo)
    {
        foreach (var file in dirInfo.GetFiles())
            yield return file;
        foreach (var dir in dirInfo.GetDirectories())
        {
            foreach (var fso in GetFileSystemObjects(dir))
                yield return fso;
            yield return dir;
        }
    }
    static void Main(string[] args)
    {
        var files = GetFileSystemObjects(new DirectoryInfo(<some path>)).OfType<FileInfo>();
        Parallel.ForEach(files, f =>
        {
            DoTheJob(f);
        });
    }
