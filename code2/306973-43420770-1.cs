    public static FileInfo[] GetFiles(string path)
    {
      return new DirectoryInfo(path).GetFiles()
                                    .OrderBy(x => x.Name, new NaturalSort())
                                    .ToArray();
    }
