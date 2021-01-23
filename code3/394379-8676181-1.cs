    class Program
    {
        static void Main(string[] args)
        {
            var fw = new FileSystemWatcher(@"M:\Videos\Unsorted");
            fw.Created += fw_Created;
            while(true) fw.WaitForChanged(WatcherChangeTypes.All);
        }
        static void fw_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("added file {0}", e.Name);
        }
    }
