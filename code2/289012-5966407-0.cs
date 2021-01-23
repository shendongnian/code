    public class FileInfoAdapter : IFileInfo
    {
        private readonly FileSystemInfo _fi;
        public FileInfoAdapter(string fileName)
            : this(new FileInfo(fileName))
        { }
        public FileInfoAdapter(FileSystemInfo fi)
        {
            _fi = fi;
        }
        public string Name { get { return _fi.Name; } }
        public string FullName { get { return _fi.FullName; } }
        public bool Exists { get { return _fi.Exists; } }
    }
