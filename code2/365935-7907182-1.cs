      private bool _disposed;
      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }
      protected virtual void Dispose(bool disposing)
      {
         if (!_disposed)
         {
            if (disposing)
            {
               // Managed
               inner.Dispose();
            }
            // Unmanaged
         }
         _disposed = true;
      }
      ~Outer()
      {
         Dispose(false);
      } 
