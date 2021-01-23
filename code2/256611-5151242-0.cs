    class Data
    {
      public string Path;
      public string Name;
      public EventWaitHandle Handle;
      public Data (string path, string name, EventWaitHandle handle)
      {
         Path = path;
         Name = name;
         Handle = handle;
      }
    }
    
    
    var threadSplit = new Thread((obj) =>
    {
      Data data = obj as Data;
      ScanProcess(data.Path, data.Name);
      data.Handle.Set();
    });
    threadSplit.Start(new Data(serverPath, serverName, handle));
