    public abstract class UploadManager
    {
       public void SaveFile(string fileName){ //uploading file }
       public abstract bool CanAccept(string sFileName); //abstract
        protected void DeleteFile(string fileName)
        {
           //Implement
        }
    }
