    public FileInfo GetRecent(string path, params string[] extensions)
    {
        List<FileInfo> list = new List<FileInfo>();
        // Getting all files having required extensions
        foreach (string ext in extensions)
            list.AddRange(new DirectoryInfo(path).GetFiles("*" + ext).Where(p =>
                  p.Extension.Equals(ext,StringComparison.CurrentCultureIgnoreCase))
                  .ToArray());
        return list.Any()
            ? list.OrderByDescending(i => i.LastWriteTime)
                  .FirstOrDefault()
            : null;
    }
