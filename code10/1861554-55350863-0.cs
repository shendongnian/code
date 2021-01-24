    class Program
    {
        public static Dictionary<string, int> dico = new Dictionary<string, int>();
        public static void CountFiles(string nameDirectory)
        {
            int nbrfiles = Directory.GetFiles(nameDirectory).Length;
            dico[targetDirectory] = nbrfiles;
            string[] subdirectories = Directory.GetDirectories(nameDirectory);
            foreach (string subdir in subdirectories)
                CountFiles(subdir);
        }
        static void Main(string[] args)
        {
            string tdir = "e:\\example";
            CountFiles(tdir);
            var totalfiles = dico.Sum(x => x.Value);
            Console.WriteLine($"Directory {tdir} contains {totalfiles} files");
            foreach (var item in dico)
            {
                Console.WriteLine($"Directory {item.Key} has {item.Value} file(s)");
            }
        }
    } 
