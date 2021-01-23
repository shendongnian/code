        public static long Size(this DirectoryInfo Directory, bool Recursive = false)
        {
            if (Directory == null)
                throw new ArgumentNullException("Directory");
            return Directory.EnumerateFiles("*", Recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).Sum(x => x.Length);
        }
