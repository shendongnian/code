    DateTime dtStart = DateTime.Now;
    const int TIMEOUT_SECONDS = 120;
    
    while (!myResult.IsCompleted)
    {
          if (DateTime.Now.Subtract(dtStart).TotalSeconds > TIMEOUT_SECONDS)
          {
               // Cleanup and bail 
          }
          myResult.AsyncWaitHandle.WaitOne(65000);
    }
