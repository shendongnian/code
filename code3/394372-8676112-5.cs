    class Program
    {
        static void Main(string[] args)
        {
            var fw = new FileSystemWatcher(@"M:\Videos\Unsorted");
            fw.Changed += fw_Changed;
            while(fw.WaitForChange(WatcherChangeTypes.All) != null);
        }
    
        static void fw_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("added file {0}", e.Name);
        }
    }
