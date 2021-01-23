      byte[] bytes = GetYourBytesFromDataBase();
      string path = Path.GetTempFileName();
      try
      {
          using(BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
          {
             writer.Write(yourBytes);
          }
     
          // open it with default application
          // you must manage the case that there's
          // no default application
          Process p = System.Diagnostics.Process.Start(path);
          p.Wait();
      }
      finally
      {
          File.Delete(path);
      }
