    public bool PurgeDirectory(string filePath)
    {
       if (Directory.Exists(filePath))
       {
          Directory.Delete(filePath);
          return true;
       }
       return false;
    }
