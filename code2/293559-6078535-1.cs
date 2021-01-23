    public class FileSystemList : IEnumerable<string>
    {
        DirectoryInfo rootDirectory;
        
        public FileSystemList(string root) 
        {
             rootDirectory = new DirectoryInfo(root);
        }
        public IEnumerator<string> GetEnumerator() 
        {
            return ProcessDirectory(rootDirectory).GetEnumerator();
        }
        public IEnumerable<string> ProcessDirectory(DirectoryInfo dir) 
        {
            yield return dir.FullName;
            foreach (FileInfo file in dir.EnumerateFiles())
                yield return file.FullName;
            foreach (DirectoryInfo subdir in dir.EnumerateDirectories())
                foreach (string result in ProcessDirectory(subdir))
                    yield return result;
        }
        IEnumerator IEnumerable.GetEnumerator() 
        {
            return GetEnumerator();
        }
    }
