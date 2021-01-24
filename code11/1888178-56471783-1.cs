    public interface IUserManagement
    {
        void Login(string username, string password);
        void Logout();
    }
    
    public interface IFileManagement
    {
        void UploadFile(string path);
        void UploadLargeFile(string path);
        void DownloadFile(string filename, string savePath);
    }
    
    public interface IFolderManagement
    {
        void DownloadFolder(string path);
        void UploadFolder(string path);
    }
