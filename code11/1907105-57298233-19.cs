    class TableRowDataModel
    {
      public TableRowDataModel(String dateTime, String source, String rootDirectory, String sourceDirectoryName, String sourcePath, String sourceFile, String targetLetter, String targetDiskName)
      {
         this.DateTime = dateTime;
         this.Source = source;
         this.RootDirectory = rootDirectory;
         this.SourceDirectoryName = sourceDirectoryName;
         this.SourcePath = sourcePath;
         this.SourceFile = sourceFile;
         this.TargetLetter = targetLetter;
         this.TargetDiskName = targetDiskName;
      }
      public String DateTime { get; set; }
      public String Source { get; set; }
      public String RootDirectory { get; set; }
      public String SourceDirectoryName { get; set; }
      public String SourcePath { get; set; }
      public String SourceFile { get; set; }
      public String TargetLetter { get; set; }
      public String TargetDiskName { get; set; }
    }
