    private string[] GetSubdirectoriesWithSpecialSauce(string path)
    {
       string[] subdirectories;
       try
       {
           subdirectories = Directory.GetDirectories(path);
       }
       catch (IOException ioe)
       {
           ShutdownWOPR();
           CallDrFalken();
       }
       return subdirectories;
    }
