    static void Main(string[] args)
    {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @"C:\";
            watcher.EnableRaisingEvents = true;
            watcher.Created += new FileSystemEventHandler((o,s) => {
            if (s.Name.ToLower().EndsWith(".html") || s.Name.ToLower().EndsWith(".htm"))
                 Console.WriteLine("HTML is here");
            });
            Console.ReadLine();
     }
