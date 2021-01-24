    public Dictionary<string, FileInfo> GetRecents(string path, params string[] extensions)
    {
        var ret = new Dictionary<string, FileInfo>();
        // Getting all files having required extensions
        // Note that extension is case insensitive with this code
        foreach (var ext in extensions)
        {
            var files = new DirectoryInfo(path)
                .EnumerateFiles("*" + ext, SearchOption.AllDirectories)
                .Where(p =>
                    p.Extension.Equals(ext, StringComparison.CurrentCultureIgnoreCase))
                .ToArray();
            ret.Add(ext, files.Any()
            ? files.OrderByDescending(i => i.LastWriteTime).FirstOrDefault()
            : null);
        }
        return ret;
    }
