        static void Main()
        {
            TraverseDirectory(@"D:\TestDirectory");
        }
        static void DoSomethingWithMaster(string path)
        {
            Console.WriteLine("Found master at {0}", path);
        }
        static void TraverseDirectory(string directory)
        {
            var currentDirectory = new DirectoryInfo(directory);
            foreach(var dir in currentDirectory.GetDirectories())
            {
                var currentPath = dir.FullName;
                TraverseDirectory(currentPath);
                if (File.Exists(Path.Combine(currentPath, "Master"))) 
                   DoSomethingWithMaster(currentPath);
            }
        }
