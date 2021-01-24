      static void Main(string[] args)
        {
            string root = @"C:\";
            LoadSubDirs(root);
            Console.ReadKey();
        }
        private static void LoadSubDirs(string dir)
        {
            Console.WriteLine(dir);
            try
            {
                string[] subdirectories = Directory.GetDirectories(dir);
                if (subdirectories != null)
                    foreach (string subdir in subdirectories)
                    {
                        LoadSubDirs(subdir);
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); //Most of the time this raise when you don't have permission on the folder
            }
        }
