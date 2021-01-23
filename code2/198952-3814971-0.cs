    public class Example
    {
      private BlockingCollection<string> m_Queue = new BlockingCollection<string>();
    
      public Example()
      {
        var thread = new Thread(Process);
        thread.IsBackground = true;
        thread.Start();
      }
    
      private void FileSystemWatcher_Event(object sender, EventArgs args)
      {
        string file = GetFilePathFromEventArgs(args);
        m_Queue.Add(file);
      }
    
      private void Process()
      {
        while (true)
        {
          string file = m_Queue.Take();
          // Process the file here.
        }
      }
    }
