    class MyFile {
      public MyFile() {
        Errors = new List<MyFileError>();
      }
  
      public string Name { get; set; }
      public string Type { get; set; }
      ...
      public List<MyFileError> Errors { get; private set; }
    }
    class MyFileError {
      public int Code { get; set; }
      public int Total { get; set; }
      public string Message { get; set; }
      ...
    }
