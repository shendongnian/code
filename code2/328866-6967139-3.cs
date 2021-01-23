    class MyClass : IDisposable
    {
      private bool disposed = false;
      void Dispose() 
      { 
        Dispose(true); 
        GC.SuppressFinalize(this);
      }
    
      protected virtual void Dispose(bool disposing)
      {
        if(!disposed)
        {
          if(disposing)
          {
            // Manual release of managed resources.
          }
          // Release unmanaged resources.
          disposed = true;
        }
      }
    
      ~MyClass() { Dispose(false); }
    }
