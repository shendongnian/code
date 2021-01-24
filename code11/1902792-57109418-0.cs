    public IsFolderVAlid(string folderPath, string filename)
    {
      if (Directory.Exists(folderPath))
      {
        var files = Directory.EnumerateFiles(folderPath,
          fileName).ToList();
        return files.Any();
      }
      return false;
    }
