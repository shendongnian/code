    class TableRowModel
    {
      public TableRowModel(String dateTime, String source, String rootDirectory, String sourceDirectoryName, String sourcePath, String sourceFile, String targetLetter, String targetDiskName)
      {
         this.dateTime = dateTime;
         this.source = source;
         this.rootDirectory = rootDirectory;
         this.sourceDirectoryName = sourceDirectoryName;
         this.sourcePath = sourcePath;
         this.sourceFile = sourceFile;
         this.targetLetter = targetLetter;
         this.targetDiskName = targetDiskName;
      }
      public String dateTime { get; set; }
      public String source { get; set; }
      public String rootDirectory { get; set; }
      public String sourceDirectoryName { get; set; }
      public String sourcePath { get; set; }
      public String sourceFile { get; set; }
      public String targetLetter { get; set; }
      public String targetDiskName { get; set; }
    }
