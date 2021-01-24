    public static RemoteWatcher RemoteWatcher1 {get; private set;}
    // On application start
    RemoteWatcher1 = new RemoteWatcher(new[] { @"\\share1\dir1", @"\\share2\dir2", @"\\share3\dir5" });
    // Search
    var results = RemoteWatcher1.SearchAllAsync(new[] { "file.txt", "file2.txt", "file3.jpg", "file4.xml", "file5.zip" }).Result;
    // On application end
    RemoteWatcher1.Dispose();
