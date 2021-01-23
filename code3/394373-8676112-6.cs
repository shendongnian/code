    class Program
    {
        static void Main(string[] args)
        {
            var fw = new FileSystemWatcher(@"M:\Videos\Unsorted");
            fw.Changed += fw_Changed;
            fw.EnableRaisingEvents = true;
            new System.Threading.AutoResetEvent(false).WaitOne();
        }
    
        static void fw_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("added file {0}", e.Name);
        }
    }
