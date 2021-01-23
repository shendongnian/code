    class Program
    {
        static void Main(string[] args)
        {
            var fw = new FileSystemWatcher(@".");
            while (true)
            {
                Console.WriteLine("added file {0}",
                    fw.WaitForChanged(WatcherChangeTypes.All).Name);
            }
        }
    }
