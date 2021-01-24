    public  bool IsFileLocked(string fileName)
    {
    
       try
       {
          using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
          {
             return false;
          }   
       }
       catch (IOException)
       {
          //the file is unavailable
          return true;
       }
    }
