    class MyClass : IDisposable
    {
      void Dispose() 
      { 
        Dispose(true); 
        GC.SupressFinalize(this);
      }
    
      protected void Dispose(bool disposing)
      {
        if(disposing)
        {
          // Manual release of managed resources.
        }
        // Release unmanaged resources.
      }
    
      ~MyClass() { Dispose(false); }
    }
