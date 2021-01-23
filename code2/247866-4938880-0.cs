    internal static class Log
    {
      private static BlockingCollection<string> s_Queue = new BlockingCollection<string>();
    
      static Log()
      {
        var thread = new Thread(Run);
        thread.IsBackground = true;
        thread.Start();
      }
    
      private static void Run()
      {
        while (true)
        {
          string line = s_Queue.Take();
          // Add code to append the line to the log here.
        }
      }
    
      internal static void WriteLine(params string[] items)
      {
        foreach (string item in items)
        {
          s_Queue.Add(item);
        }
      }
    }
