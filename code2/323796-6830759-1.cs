    public class Example
    {
      public void ProcessAllFilesAsync()
      {
        var semaphores = new Dictionary<string, Semaphore>();
        foreach (string filePath in GetFiles())
        {
          string filePathCapture = filePath; // Needed to perform the closure correctly.
          string directoryPath = Path.GetDirectoryName(filePath);
          if (!semaphores.ContainsKey(directoryPath))
          {
            int allowed = NUM_OF_CONCURRENT_OPERATIONS;
            semaphores.Add(directoryPath, new Semaphore(allowed, allowed));
          }
          var semaphore = semaphores[directoryPath];
          ThreadPool.QueueUserWorkItem(
            (state) =>
            {
              semaphore.WaitOne();
              try
              {
                DoFtpOperation(filePathCapture);
              }
              finally
              {
                semaphore.Release();
              }
            }, null);
        }
      }
    }
