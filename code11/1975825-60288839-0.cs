    public string SearchDirectory(string dir, string fileName)
    {
      return Directory
        .EnumerateFiles(dir, fileName, SearchOption.AllDirectories)
        .FirstOrDefault() ?? "";
    }
