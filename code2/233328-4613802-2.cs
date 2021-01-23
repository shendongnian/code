      byte[] bytes = GetYourBytesFromDataBase();
      string extension = GetFileExtension(); //.doc for example
      string path = Path.GetTempFileName() + extension;
      try
      {
          using(BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
          {
             writer.Write(yourBytes);
          }
     
          // open it with default application based in the
          // file extension
          Process p = System.Diagnostics.Process.Start(path);
          p.Wait();
      }
      finally
      {
          //clean the tmp file
          File.Delete(path);
      }
