    abstract class MyClass : IDisposable { 
    
      private SafeFileHandle _handle;
    
      public void Dispose() { 
        Dispose(true);
        GC.SupressFinalization(this);
      }
      
      ~MyClass() {
        Dispose(false);
      }
      
      protected virtual void Dispose(bool disposing) {
        if (disposing) {
          WriteTheFile();
        }
        _handle.Dispose();
      }
    
    }
