    public interface IFileService
    {
        string[] GetFiles(string path);
        void Move(string sourceFileName, string destFileName);
    }
