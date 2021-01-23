    class Program
    {
        private FileSystemWatcher _watcher;
        public Program()
        {
            FileWatcherEvents fwe = new FileWatcherEvents();
            this._watcher = new System.IO.FileSystemWatcher();
            this._watcher.Filter = "*.txt";
            this._watcher.NotifyFilter = ((System.IO.NotifyFilters)(((((
                System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.DirectoryName) 
                | System.IO.NotifyFilters.LastWrite) | System.IO.NotifyFilters.LastAccess) 
                | System.IO.NotifyFilters.CreationTime)));
            this._watcher.Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 
            this._watcher.Deleted += new System.IO.FileSystemEventHandler(fwe.ShipmentFileCreated); 
            this._watcher.Created += new System.IO.FileSystemEventHandler(fwe.FileDeleted);
            this._watcher.EnableRaisingEvents = true;
            Console.ReadLine();
        }
        public static void Main()
        {
            Program prg = new Program();
            using (System.IO.StreamWriter w = new System.IO.StreamWriter(
                System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TestFile.txt"), false))
            {
                w.WriteLine(DateTime.Now.ToLongTimeString());
            }
            Console.ReadLine();
        }
    }
    class FileWatcherEvents
    {
        public void ShipmentFileCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("CREATED: " + sender.ToString() + e.ToString());
        }
        public void FileDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("DELETED: " + sender.ToString() + e.ToString());
        }
    }
