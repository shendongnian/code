    public class Foo : IDisposable
    {
      private Socket _socket { get; }
      private bool IsDisposed;
      public Foo()
      {
        _socket = new Socket();
      }
      public void Dispose()
      {
        Dispose(true);
        GC.SuppressFinalize(this);
      }
      protected virtual void Dispose(bool disposing)
      {
        if ( IsDisposed ) return;
        if ( disposing )
        {
          if ( _socket != null )
          {
            _socket.Dispose();
            _socket = null;
          }
        }
        IsDisposed = true;
      }
    }
