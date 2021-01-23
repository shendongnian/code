    public static IEnumerable<string> GetUnprocessedFiles(IEnumerable<string> allFiles, IEnumerable<string> processedFiles)
    {
      // null-checks here
      return allFiles.Except(processedFiles);     
    }
