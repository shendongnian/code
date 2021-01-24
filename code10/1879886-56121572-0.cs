    public class MySpaceManager()
    {
      private readonly IFileManager _fileManager;
      public MySpaceManager(IFileManager fileManager)
      {
        _fileManager = fileManager;
      }
      public bool TryDeleteAllFiles1(logicalDirectory)
      {
        var files = _fileManager.GetFiles(logicalDirectory);
        var result = true;
        foreach(var file in files)
          result = result && _fileManager.Delete(file);
        return result;
      }
      // or maybe
      public bool TryDeleteAllFiles2(logicalDirectory)
      {
        var files = _fileManager.GetFiles(logicalDirectory);
        foreach(var file in files)
          _fileManager.Delete(file);
        var result = _fileManager.GetFiles(logicalDirectory).Count() == 0;
        return result;
      }
    }
