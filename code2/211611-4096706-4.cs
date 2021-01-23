    public static List<FileInfo> GetUnprocessedFiles(FileInfo[] allFiles, 
                                             List<string> processedFiles)
    {
       List<FileInfo> unprocessedFiles = new List<FileInfo>();
       HashSet<string> processedFileSet = new HashSet<string>(processedFiles);
       foreach (FileInfo fileInfo in allFiles)
       {
           if (!processedFileSet.Contains(fileInfo.Name))
           {
               unprocessedFiles.Add(fileInfo);
           }
        }
       return unprocessedFiles;
    }
