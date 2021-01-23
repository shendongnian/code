    class Program
    {
        private static int numFolders = 10000;
        private static string rootDirectory = "C:\\1";
    
        static void Main(string[] args)
        {
            if (Directory.Exists(rootDirectory))
            {
                Directory.Delete(rootDirectory, true);
                Thread.Sleep(5000);
            }
    
            Stopwatch sw = Stopwatch.StartNew();
            CreateFolder();
            long time = sw.ElapsedMilliseconds;
    
            Console.WriteLine(time);
            Console.ReadLine();
        }
    
        private static void CreateFolder()
        {
            var one = Directory.CreateDirectory(rootDirectory);
    
            for (int i = 1; i <= numFolders; i++)
            {
                one.CreateSubdirectory(i.ToString());
            }
        }
    }
