    public interface IFileFinder { bool FileExists(string path); }
    
    // Concrete implementation to use in production
    public class FileFinder: IFileFinder {
        public bool FileExists(string path) { return File.Exists(path); }
    }
    public class Merger {
        IFileFinder finder;
        public Merger(IFileFinder finder) { this.finder = finder; }
    }
