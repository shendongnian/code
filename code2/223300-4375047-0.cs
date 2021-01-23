namespace RecursiveDirCompare
{
    class Program
    {
        static List<string> initialFiles = new List<string>();
        static void Main(string[] args)
        {
            string root = args[0];
            string compare = args[1];
                AddFilesToInitialList(root);
                CompareWithInitialList(compare);
            Console.ReadKey();
        }
        static void AddFilesToInitialList(string root)
        {
            foreach (string file in Directory.GetFiles(root))
            {
                initialFiles.Add(file);
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
                if(initialFiles.Contains(file))
                {
                    Console.WriteLine(file + " is found in both");
                }
            }
            foreach (string directory in Directory.GetDirectories(root))
            {
                AddFilesToInitialList(directory);
            }            
        }
    }
}
