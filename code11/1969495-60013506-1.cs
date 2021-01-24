    public IEnumerable<FileInfo> GetMostRecentFilesByExtension(string path, IEnumerable<string> extensions, bool returnSingle)
    {
        var mostRecent = MostRecentFileByExtension(path, extensions).Where(fi => fi != null);
        if (returnSingle) {
            return mostRecent.OrderByDescending(fi => fi.LastWriteTime).Take(1);
        }
        else {
            return mostRecent;
        }
    }
    private IEnumerable<FileInfo> MostRecentFileByExtension(string path, IEnumerable<string> exts)
    {
        foreach (string dir in Directory.EnumerateDirectories(path, "*", SearchOption.AllDirectories).Prepend(path))
        foreach (string ext in exts) {
            yield return new DirectoryInfo(dir)
                            .EnumerateFiles($"*{ext}")
                            .Where(fi => fi.Extension.Equals(ext, StringComparison.InvariantCultureIgnoreCase))
                            .OrderByDescending(fi => fi.LastWriteTime).FirstOrDefault();
        }
    }
