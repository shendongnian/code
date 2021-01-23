    abstract class MyClass : IDisposable { 
    
      private SafeFileHandle _handle;
    
      public void Dispose() { 
        WriteTheFile();
        _handle.Dispose();
      }
    
    }
