    class Program
    {
        static StringBuilder builder = new StringBuilder();
        static void Main(string[] args)
        {
            if (args.Length == 0)
                return;
 
            ProcessDirectories(args[0]);
            
            // Save file here
        }
        static void ProcessDirectories(string root)
        {
            ProcessDirectory(new DirectoryInfo(root));
            var subDirectories = Directory.GetDirectories(root);
            if (subDirectories.Length == 0)
                return;
            foreach (var subDirectory in subDirectories)
            {
                ProcessDirectories(subDirectory);
            }
        }
        static void ProcessDirectory(DirectoryInfo directory)
        {
            foreach (var file in directory.EnumerateFiles())
            {
                builder.AppendFormat("----- {0} -----", file.FullName);
                using (var reader = file.OpenText())
                {
                    builder.AppendLine(reader.ReadToEnd());
                }
            }
        }
    }
