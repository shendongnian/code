    public class MessageFileWatcher
    {
       public MessageFileWatcher(string Path, string FileName)
       {
          FileSystemWatcher Watcher = new FileSystemWatcher();
          Watcher.Path = Path;
          Watcher.Filter = FileName;
          Watcher.NotifyFilter = NotifyFilters.LastWrite;
          Watcher.Changed += new FileSystemEventHandler(OnChanged);
          Watcher.EnableRaisingEvents = true;
       }
    
       private void OnChanged(object source, FileSystemEventArgs e)
       {
          // Do something here based on the change to the file
       }
    }
