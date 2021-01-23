    public FileInfo[] GetFiles(DirectoryInfo dir, string searchPatterns, params char[] separator)
    {
       ArrayList files = new ArrayList();
       string[] patterns = searchPatterns.Split(separator);
       foreach (string pattern in patterns)
       {
          if (pattern.Length != 0)
          {
             files.AddRange(dir.GetFiles(pattern));
          }
       }
       return (FileInfo[])files.ToArray(typeof(FileInfo));
    }
