    public class Example
    {
      public void ProcessAllFilesAsync()
      {
        var semaphores = new Dictionary<string, SemaphoreSlim>();
        foreach (string filePath in GetFiles())
        {
          string filePathCapture = filePath; // Needed to perform the closure correctly.
          string directoryPath = Path.GetDirectoryName(filePath);
          if (!semaphores.ContainsKey(directoryPath))
          {
            semaphores.Add(directoryPath, new SemaphoreSlim(NUMBER_OF_CONCURRENT_OPERATIONS));
          }
          var semaphore = semaphores[directoryPath];
          ThreadPool.QueueUserWorkItem(
            (state) =>
            {
              semaphore.Wait();
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
