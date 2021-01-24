    public static class ParseDir
    {
        public static FileInfo[] GetFilesFromDirectory(string DirName, string pattern, bool Recursive)
        {
            if (!Directory.Exists(DirName))
                throw new Exception("No such Directory.");
            DirectoryInfo dirInfo = new DirectoryInfo(DirName);
            SearchOption Recur = Recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            return dirInfo.GetFiles(pattern, Recur);
        }
    
        public static FileInfo[] GetHiddenOnlyFiles(FileInfo[] Files)
        {
            List<FileInfo> result = new List<FileInfo>();
            foreach (FileInfo file in Files)
                if ((file.Attributes & System.IO.FileAttributes.Hidden) == System.IO.FileAttributes.Hidden)
                    result.Add(file);
            return result.ToArray();
        }
    
    }
