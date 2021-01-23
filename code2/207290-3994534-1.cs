        private bool FileExists(string rootpath, string filename)
        {
            if(File.Exists(Path.Combine(rootpath, filename)))
                return true;
            foreach(string subDir in Directory.GetDirectories(rootpath, "*", SearchOption.AllDirectories))
            {
                if(File.Exists(Path.Combine(rootpath, filename)))
                return true;
            }
            return false;
        }
        private bool FileExistsRecursive(string rootPath, string filename)
        {
            if(File.Exists(Path.Combine(rootPath, filename)))
                return true;
            foreach (string subDir in Directory.GetDirectories(rootPath))
            {
                return FileExistsRecursive(subDir, filename);
            }
            return false;
        }
