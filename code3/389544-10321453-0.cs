    public static class FileDirectorySearcher
    {
        public static IEnumerable<string> Search(string searchPath, string searchPattern)
        {
            IEnumerable<string> files = GetFileSystemEntries(searchPath, searchPattern);
            foreach (string file in files)
            {
                yield return file;
            }
            IEnumerable<string> directories = GetDirectories(searchPath);
            foreach (string directory in directories)
            {
                files = Search(directory, searchPattern);
                foreach (string file in files)
                {
                    yield return file;
                }
            }
        }
        private static IEnumerable<string> GetDirectories(string directory)
        {
            IEnumerable<string> subDirectories = null;
            try
            {
                subDirectories = Directory.EnumerateDirectories(directory, "*.*", SearchOption.TopDirectoryOnly);
            }
            catch (UnauthorizedAccessException)
            {
            }
            if (subDirectories != null)
            {
                foreach (string subDirectory in subDirectories)
                {
                    yield return subDirectory;
                }
            }
        }
        private static IEnumerable<string> GetFileSystemEntries(string directory, string searchPattern)
        {
            IEnumerable<string> files = null;
            try
            {
                files = Directory.EnumerateFileSystemEntries(directory, searchPattern, SearchOption.TopDirectoryOnly);
            }
            catch (UnauthorizedAccessException)
            {
            }
            if (files != null)
            {
                foreach (string file in files)
                {
                    yield return file;
                }
            }
        }
    }
