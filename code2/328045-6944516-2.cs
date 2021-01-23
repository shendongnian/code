      public class Monitor : IDisposable
      {
         private List<string> filePaths;
         private ReaderWriterLockSlim rwlock;
         private Timer processTimer;
         private string watchedPath;
         private FileSystemWatcher watcher;
         public Monitor(string watchedPath)
         {
            filePaths = new List<string>();
            rwlock = new ReaderWriterLockSlim();
            this.watchedPath = watchedPath;
            InitFileSystemWatcher();
         }
         private void InitFileSystemWatcher()
         {
            watcher = new FileSystemWatcher();
            watcher.Filter = "*.*";
            watcher.Created += Watcher_FileCreated;
            watcher.Error += Watcher_Error;
            watcher.Path = watchedPath;
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
         }
         private void Watcher_Error(object sender, ErrorEventArgs e)
         {
            // Watcher crashed. Re-init.
            InitFileSystemWatcher();
         }
         private void Watcher_FileCreated(object sender, FileSystemEventArgs e)
         {
            try
            {
               rwlock.EnterWriteLock();
               filePaths.Add(e.FullPath);
               if (processTimer == null)
               {
                  // First file, start timer.
                  processTimer = new Timer(2000);
                  processTimer.Elapsed += ProcessQueue;
                  processTimer.Start();
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
         private void ProcessQueue(object sender, ElapsedEventArgs args)
         {
            try
            {
               Console.WriteLine("Processing queue, " + filePaths.Count + " files created:");
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
                  processTimer.Stop();
                  processTimer.Dispose();
                  processTimer = null;
               }
               rwlock.ExitReadLock();
            }
         }
         protected virtual void Dispose(bool disposing)
         {
            if (disposing)
            {
               if (rwlock != null)
               {
                  rwlock.Dispose();
                  rwlock = null;
               }
               if (watcher != null)
               {
                  watcher.EnableRaisingEvents = false;
                  watcher.Dispose();
                  watcher = null;
               }
            }
         }
         public void Dispose()
         {
            Dispose(true);
            GC.SuppressFinalize(this);
         }
      }     
