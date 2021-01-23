    class Program
    {
        static List<FileSystemWatcher> _watchers = new List<FileSystemWatcher>();
        static bool _shouldReload = false;
        static void WaitReady(string fileName)
        {
            while (true)
            {
                try
                {
                    using (Stream stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {
                        if (stream != null)
                        {
                            System.Diagnostics.Trace.WriteLine(string.Format("Output file {0} ready.", fileName));
                            break;
                        }
                    }
                }
                catch (FileNotFoundException ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("Output file {0} not yet ready ({1})", fileName, ex.Message));
                }
                catch (IOException ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("Output file {0} not yet ready ({1})", fileName, ex.Message));
                }
                catch (UnauthorizedAccessException ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("Output file {0} not yet ready ({1})", fileName, ex.Message));
                }
                Thread.Sleep(500);
            }
        }
        static void Main(string[] args)
        {
            var configWatcher = new FileSystemWatcher(Path.GetDirectoryName(Path.GetFullPath("config.xml")), "config.xml");
            configWatcher.Changed += (o, e) =>
            {
                lock (_watchers)
                {
                    _watchers.ForEach(w => { w.EnableRaisingEvents = false; w.Dispose(); });
                    _watchers.Clear();
                }
                _shouldReload = true;
            };
            configWatcher.EnableRaisingEvents = true;
            Thread t = new Thread((ThreadStart)(() => {
                while (true)
                {
                    Thread.Sleep(5000); // reload only every five seconds (safety measure)
                    if (_shouldReload)
                    {
                        _shouldReload = false;
                        Console.WriteLine("Reloading configuration.");
                        WaitReady(Path.GetFullPath("config.xml"));
                        loadConfigAndRun();
                    }
                }
            }));
            t.IsBackground = true;
            t.Start();
            
            loadConfigAndRun();
            Console.ReadLine();
        }
        static void loadConfigAndRun()
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
                _watchers.Add(watcher);
            }
        }
        static void toggleWatcher(string path)
        {
            var watcher = _watchers.FirstOrDefault(w => w.Path == path);
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
