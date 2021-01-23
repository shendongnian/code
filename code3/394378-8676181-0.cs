    class Program
    {
        static void Main(string[] args)
        {
            var fw = new FileSystemWatcher(@"M:\Videos\Unsorted");
            fw.EnableRaisingEvents = true;
            fw.Created += fw_Created;
            Console.ReadLine();
        }
        static void fw_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("added file {0}", e.Name);
        }
    }
