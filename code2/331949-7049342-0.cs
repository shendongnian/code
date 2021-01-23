    public sealed class FileData
    {
        // Or use private readonly string variables and getter-only properties
        public string FileName { get; private set; }
        public string Path { get; private set; }
        public string DirectoryName { get; private set; }
        public FileData(string fileName, string path, string directoryName)
        {
            FileName = fileName;
            Path = path;
            DirectoryName = directoryName;
        }
        // Optional: override methods from System.Object.
        // ToString might be really handy; Equals/GetHashCode less likely.
    }
