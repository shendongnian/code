      private bool _disposed;
      public void Dispose()
      {
         Dispose( true );
         GC.SuppressFinalize( this );
      }
      protected virtual void Dispose( bool disposing )
      {
         if ( disposing )
         {
            if ( !_disposed )
            {
               if ( Bar != null )
               {
                  Bar.Dispose();
               }
               _disposed = true;
            }
         }
      }
