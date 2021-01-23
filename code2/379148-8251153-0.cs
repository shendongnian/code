        static List<DirectoryInfo> getAllSubdirectories(DirectoryInfo dir)
        {
            List<DirectoryInfo> subDirs = new List<DirectoryInfo>();
            Stack<DirectoryInfo> toProcess = new Stack<DirectoryInfo>();
            toProcess.Push(dir);
            while(toProcess.Count > 0) {
                subDirs.AddRange(toProcess.Pop().GetDirectories());
            }
    
            return subDirs;
        }
