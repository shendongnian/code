      public bool ContainsFiles(string dirName)
      {
         if (Directory.GetFiles(dirName).Any()) return true;
         return Directory.GetDirectories(dirName).Any(subDir => ContainsFiles(subDir));
      }
