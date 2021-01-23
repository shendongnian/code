    class Program
    {
        static void Main(string[] args)
        {
            var watcher = new FileSystemWatcher { Path = @"c:\temp", Filter = "*.txt" };
            watcher.Deleted += watcher_Deleted;
            watcher.EnableRaisingEvents = true;
            Console.ReadLine();
        }
        static void watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            var watcher = sender as FileSystemWatcher;
        }
    }
