    public class ConcreteFileSystem : IFileSystem {
        public virtual string CombinePaths(string path1, string path2) {
            return System.IO.Path.Combine(path1, path2);
        }
    
        public virtual string ReadFile(string path) {
            return System.IO.File.ReadAllText(path);
        }
    }
