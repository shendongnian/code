    bool CanRead(FileInfo file)
    {
      try {
        file.GetAccessControl();
        //Read and write access;
        return true;
      }
      catch (UnauthorizedAccessException uae)
      {
        if (uae.Message.Contains("read-only"))
        {
          //read-only access
          return true;
        }
        return false;
      }
    }
