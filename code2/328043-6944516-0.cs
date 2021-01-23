     public class Monitor
     {
        private List<string> filePaths;      
        private ReaderWriterLockSlim rwlock;
        private Timer processTimer;
        public Monitor(string path)
        {                  
           filePaths = new List<string>();
           rwlock = new ReaderWriterLockSlim();
           FileSystemWatcher watcher = new FileSystemWatcher();
           watcher.Filter = "*.*";
           watcher.Created += watcher_FileCreated;
           watcher.Path = path;
           watcher.IncludeSubdirectories = true;
           watcher.EnableRaisingEvents = true;
        }
        private void ProcessQueue()
        {
           try
           {
              Console.WriteLine("Processing queue, "+filePaths.Count + " files created:");
              rwlock.EnterReadLock();
              foreach (string filePath in filePaths)
              {
                 Console.WriteLine(filePath);
              }            
              filePaths.Clear();
           }
           finally
           {                      
              if (processTimer != null)
              {
                 processTimer.Dispose();
                 processTimer = null;
              }
              rwlock.ExitReadLock();
           }
        }
        void watcher_FileCreated(object sender, FileSystemEventArgs e)
        {
           try
           {
              rwlock.EnterWriteLock();
              filePaths.Add(e.FullPath);
              if (processTimer == null)
              {
                 // First file, start timer.
                 processTimer = new Timer(2000);
                 processTimer.Elapsed += (o, ee) => ProcessQueue();
              }
              else
              {
                 // Subsequent file, reset timer.
                 processTimer.Stop();
                 processTimer.Start();               
              }
                        
           }
           finally
           {
              rwlock.ExitWriteLock();
           }
        }
     }
