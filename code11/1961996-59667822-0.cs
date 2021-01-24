    private static void OnError(object sender, ErrorEventArgs e)
    {
      Exception ex = e.GetException();
      if (ex is Win32Exception && (((Win32Exception)ex).NativeErrorCode == 5))
      {
        Console.WriteLine($"Directory deleted permanently: { watcher.Path }");
      }
    }
    
    private static void OnChanged(object sender, FileSystemEventArgs e)
    {
      if (!Directory.Exists(watcher.Path))
      {
        Console.WriteLine($"Directory deleted (recycle bin): { watcher.Path }");
      }
    }
