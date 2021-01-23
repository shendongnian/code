    private static readonly object locker = new object();
      public static void OnlyOneCallerAllowed()
      {
        lock (locker)
        {
         string tempFileName = System.IO.Path.GetTemptempFileName();
         xmlDoc.Save(tempFileName);
          File.Move(original_file, original_file.old);
          File.Move(tempFileName,original_file);
          File.Delete( tempFileName);
        }
      }
