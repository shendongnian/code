    static void Main(string[] args)
            {
               FileSystemWatcher fs = new FileSystemWatcher(@"C:\Temp");
               fs.Changed += new FileSystemEventHandler(fs_Changed);
               fs.WaitForChanged(WatcherChangeTypes.Changed);
               while (true)
               { 
                  // Just keep console window open so you 
                  // can see events when you change a file
               }
            }
      static void  fs_Changed(object sender, FileSystemEventArgs e)
            {
     	        Console.WriteLine("File {0} changed", e.Name);
            }
