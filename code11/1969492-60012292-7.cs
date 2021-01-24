    public FileInfo GetRecent(string path, params string[] extensions)
    {
        var list = new List<FileInfo>();
        
        // Getting all files having required extensions
        // Note that extension is case insensitive with this code
        foreach (var ext in extensions)
            list.AddRange(
              new DirectoryInfo(path)
                .EnumerateFiles("*" + ext, SearchOption.AllDirectories)
                .Where(p =>
                  p.Extension.Equals(ext,StringComparison.CurrentCultureIgnoreCase))
                  .ToArray());
        return list.Any()
            // If list has somm file then return the newest one
            ? list.OrderByDescending(i => i.LastWriteTime)
                  .FirstOrDefault()
            // else return what you please, it could be null
            : null;
    }
