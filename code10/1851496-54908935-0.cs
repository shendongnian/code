    public class LargeClassObject : IDisposable
    {
       var disposed = false;
       var handle = new SafeFileHandle(IntPtr.Zero, true);
       
       public void Dispose()
       { 
          Dispose(true);
          GC.SuppressFinalize(this);           
       }
       
       protected virtual void Dispose(bool disposing)
       {
          if (disposed)
             return; 
          
          if (disposing) {
             handle.Dispose();
          }
          
          disposed = true;
       }
    }
