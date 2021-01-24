    public interface IFileStorage
    {
        string GetPath(string smth);
        void DeleteFolder(string name);
        bool IsFolderEmpty(string path);    
    }
    
    public sealed class FtpFileStorage : IFileStorage
    {
        public string GetPath(string smth) { throw new NotImplementedException(); }
        public void DeleteFolder(string name) { throw new NotImplementedException(); }
        public bool IsFolderEmpty(string path) { throw new NotImplementedException(); }
    }
