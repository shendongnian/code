namespace RecursiveDirCompare
{
    class Program
    {
        static List<string> initialFiles = new List<string>();
        static string initRoot = @"root";
        static string initCompare = @"compare";
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory( @"C:\Temp\test\");
            initRoot = @"root";// args[0];
            initCompare = @"compare";// args[1];
            AddFilesToInitialList(initRoot);
            CompareWithInitialList(initCompare);
            Console.ReadKey();
        }
        static void AddFilesToInitialList(string root)
        {
            foreach (string file in Directory.GetFiles(root))
            {
                initialFiles.Add(file.Replace(initRoot, ""));
            }
            foreach (string directory in Directory.GetDirectories(root))
            {
                AddFilesToInitialList(directory);
            }
        }
        static void CompareWithInitialList(string root)
        {
            foreach (string file in Directory.GetFiles(root))
            {
                if(initialFiles.Contains(file.Replace(initCompare, "")))
                {
                    Console.WriteLine(file + " is found in both");
                }
            }
            foreach (string directory in Directory.GetDirectories(root))
            {
                CompareWithInitialList(directory);
            }            
        }
    }
}
