    private static readonly object _syncObject = new object();
    public static void Log(string logMessage, TextWriter w)    {
       // only one thread can own this lock, so other threads
       // entering this method will wait here until lock is
       // available.
       lock(_syncObject) {
          w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
              DateTime.Now.ToLongDateString());
          w.WriteLine("  :");
          w.WriteLine("  :{0}", logMessage);
          w.WriteLine("-------------------------------");
          // Update the underlying file.
          w.Flush();
       }
    }
