    class Program
    {
        private static void PrintSubFolders(DirectoryInfo dir, string separator = "-")
        {
            Console.WriteLine(separator + dir.FullName);
            var directories = dir.GetDirectories();
            var files = dir.GetFiles();
            foreach (var file in files)
            {
                Console.WriteLine(separator + file.FullName);
            }
            foreach (var folder in directories)
            {
                PrintSubFolders(folder, separator+separator[0]);
            }
        }
        private static void PrintSubFolders(string path)
        {
            PrintSubFolders(new DirectoryInfo(path));
        }
        static void Main(string[] args)
        {
            PrintSubFolders(@"C:\Users\Vladislav\Documents\GIT Repos");
            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }
    }
