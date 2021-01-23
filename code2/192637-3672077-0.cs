    static void FullDirList(DirectoryInfo dir, string searchPattern)
    {
      Console.WriteLine("Directory {0}", dir.FullName);
      // list the files
      foreach (FileInfo f in dir.GetFiles(searchPattern))
      {
        Console.WriteLine("File {0}", f.FullName);
      }
      // process each directory
      foreach (DirectoryInfo d in dir.GetDirectories())
      {
        FullDirList(d, searchPattern);
      }
    }
