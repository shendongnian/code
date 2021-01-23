    private void worker_DoWork(object sender, DoWorkEventArgs e) 
    {
       int value = (int) e.Argument;   // the 'argument' parameter resurfaces here
      
       ...
       // and to transport a result back to the main thread
       double result = 0.1 * value;
       e.Result = result;
    }
    private void worker_Completed(object sender, RunWorkerCompletedEventArgs e) 
    {
      // check error, check cancel, then use result
      if (e.Error != null)
      {
         // handle the error
      }
      else if (e.Cancelled)
      {
         // handle cancellation
      }
      else
      {
          // reading e.Result when e.Error != null throws the exception
          double result = (double) e.Result;
          // use it on the UI thread
      }    
    }
