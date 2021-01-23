      void ThreadMethod(object state)
      {
          try
          {
              ActualWorkerMethod();
          }
          catch (Exception err)
          {
              _logger.Error("Unhandled exception in thread.", err);
          }
      }
    
      void ActualWorkerMethod()
      {
          // do something clever
      }
