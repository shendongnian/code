    private static readonly object locker = new object();
      public static void OnlyOneCallerAllowed()
      {
        lock (locker)
        {
         string tempFileName = System.IO.Path.GetTemptempFileName();
         xmlDoc.Save(tempFileName)
          Move original_file to original_file.old
          Move tempFileName to original_file
          Delete tempFileName
        }
      }
