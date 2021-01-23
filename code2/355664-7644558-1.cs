    void LongRunningMethodSync()
    {
      try
      {
        StartUpdating(); 
        // do something synchronously
      }
      finally
      {
        EndUpdating();
      }
    }
    void LongRunningMethodAsync()
    {
      StartUpdating(); 
      ExecuteMyAsyncTask(done => EndUpdating());
    }
