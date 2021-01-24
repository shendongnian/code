    class Program
    {
       //Result Variable
        public static List<string> finalRes = new List<string>();
       //Level at which you want 
        public static int reqLevel = 3;
        static void Main(string[] args)
        {
            try
            {
                var path = @"D:\Personal\";
                GetFolederNames(path, 0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public static void GetFolederNames(string path, int level)
        {
            var subDirs = new List<string>();
            subDirs = Directory.GetDirectories(path).ToList();
            if (level == reqLevel)
            {
                finalRes.Add(path);
                return;
            }
            foreach (var dir in subDirs)
            {
                if(finalRes.Contains(dir))
                    continue;
                
                GetFolederNames(dir, level+1);
            }
        }
    }
