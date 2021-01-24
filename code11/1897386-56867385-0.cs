    public class MyService
    {
        private readonly IFileSystem _fileSystem;
        public MyService(IFileSystem fileSystem)
        {
            this._fileSystem = fileSystem;
        }
        public string[] GetFileNames()
        {
            return _fileSystem.Directory.GetFiles(_fileSystem.Directory.GetCurrentDirectory());
        }
    }
