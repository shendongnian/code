    public FileInfo GetRecent(string path, params string[] extensions)
    {
        List<FileInfo> list = new List<FileInfo>();
        
        // Getting all files having required extensions
        // Note that extension is case insensitive with this code
        foreach (string ext in extensions)
            list.AddRange(
              new DirectoryInfo(path, SearchOption.AllDirectories)
                .GetFiles("*" + ext)
                .Where(p =>
                  p.Extension.Equals(ext,StringComparison.CurrentCultureIgnoreCase))
                  .ToArray());
        return list.Any()
            // If list has somme file then return the newest one
            ? list.OrderByDescending(i => i.LastWriteTime)
                  .FirstOrDefault()
            // else NULL
            : null;
    }
