    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(()=> DoTest());
            t.Start();
            
            Console.WriteLine("Waiting...");
            Console.ReadKey();
        }
        private static void DoTest()
        {
            FileSystemWatcher fsw = new FileSystemWatcher("C:\\");
            fsw.Filter = "*.txt";
            fsw.Changed += new FileSystemEventHandler(fsw_Changed);
            fsw.Deleted += new FileSystemEventHandler(fsw_Deleted);
            fsw.Renamed += new RenamedEventHandler(fsw_Renamed);
            fsw.Created += new FileSystemEventHandler(fsw_Created);
            fsw.EnableRaisingEvents = true;
        }
        static void fsw_Created(object sender, FileSystemEventArgs e)
        {
            FileInfo fi = new FileInfo(e.FullPath);
            Console.WriteLine("File Created: "+e.FullPath);
            Console.WriteLine("Creation Time: " + fi.CreationTime.ToLongTimeString());
            Console.WriteLine("Last Access Time: " + fi.LastAccessTime.ToLongTimeString());
            Console.WriteLine("Last Write Time: " + fi.LastWriteTime.ToLongTimeString());
            Console.WriteLine("Length: " + fi.Length);
            
        }
        static void fsw_Renamed(object sender, RenamedEventArgs e)
        {
            FileInfo fi = new FileInfo(e.FullPath);
            Console.WriteLine("File Renamed: "+e.FullPath);
            Console.WriteLine("Creation Time: " + fi.CreationTime.ToLongTimeString());
            Console.WriteLine("Access Time: " + fi.LastAccessTime.ToLongTimeString());
            Console.WriteLine("Last Write Time: " + fi.LastWriteTime.ToLongTimeString());
            Console.WriteLine("Length: " + fi.Length);
        }
        static void fsw_Deleted(object sender, FileSystemEventArgs e)
        {
            FileInfo fi = new FileInfo(e.FullPath);
            Console.WriteLine("File Deleted: "+e.FullPath);
            Console.WriteLine("Creation Time: " + fi.CreationTime.ToLongTimeString());
            Console.WriteLine("Last Access Time: " + fi.LastAccessTime.ToLongTimeString());
            Console.WriteLine("Last Write Time: " + fi.LastWriteTime.ToLongTimeString());
            
        }
        static void fsw_Changed(object sender, FileSystemEventArgs e)
        {
            FileInfo fi = new FileInfo(e.FullPath);
            Console.WriteLine("File Changed: "+e.FullPath);
            Console.WriteLine("Creation Time: " + fi.CreationTime.ToLongTimeString());
            Console.WriteLine("Last Access Time: " + fi.LastAccessTime.ToLongTimeString());
            Console.WriteLine("Last Write Time: " + fi.LastWriteTime.ToLongTimeString());
            Console.WriteLine("Length: " + fi.Length);
        }
    }
