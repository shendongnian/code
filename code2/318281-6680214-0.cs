        class Program
        {
            static List<FileSystemWatcher> watchers = new List<FileSystemWatcher>();
    
            static void Main(string[] args)
            {
                var config = XElement.Load("config.xml").Elements();
    
                var paths = from watcher in config select watcher.Attribute("Folder").Value;
    
                foreach (var path in paths)
                {
                    var watcher = new FileSystemWatcher(path);
                    watcher.Created += new FileSystemEventHandler(watcher_Changed);
                    watcher.Changed += new FileSystemEventHandler(watcher_Changed);
                    watcher.Deleted += new FileSystemEventHandler(watcher_Changed);
                    watcher.Renamed += new RenamedEventHandler(watcher_Renamed);
                    watcher.EnableRaisingEvents = true;
                    watchers.Add(watcher);
                }
    
                Console.ReadLine();
            }
    
            static void toggleWatcher(string path)
            {
                var watcher = watchers.FirstOrDefault(w => w.Path == path);
    
                if (watcher != null)
                {
                    watcher.EnableRaisingEvents = !watcher.EnableRaisingEvents;
                }
            }
    
            static void watcher_Renamed(object sender, RenamedEventArgs e)
            {
                var watcher = sender as FileSystemWatcher;
    
                Console.WriteLine("Something renamed in " + watcher.Path);
            }
    
            static void watcher_Changed(object sender, FileSystemEventArgs e)
            {
                var watcher = sender as FileSystemWatcher;
    
                Console.WriteLine("Something changed in " + watcher.Path);
            }
        }
