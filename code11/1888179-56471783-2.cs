    public class MyFileManager : IFileManagement
    {
        public void DownloadFile(string filename, string savePath)
        {
            //Add code here
        }
    
        public void UploadFile(string path)
        {
            //Add code here
        }
    
        public void UploadLargeFile(string path)
        {
            //Add code here
        }
    }
    
    public class MyUserManager : IUserManagement
    {
        public void Login(string username, string password)
        {
            //Add code here
        }
    
        public void Logout()
        {
            //Add code here
        }
    }
    
    public class MyFoldermanager : IFolderManagement
    {
        public void DownloadFolder(string path)
        {
            //Add code here
        }
    
        public void UploadFolder(string path)
        {
            //Add code here
        }
    }
