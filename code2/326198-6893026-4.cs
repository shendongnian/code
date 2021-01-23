    public interface IFileWrapper {
        bool Exists(string path);
    }
    
    public class FileWrapper : IFileWrapper {
        public bool Exists(string path) {
            return File.Exists(path);
        }
    }
