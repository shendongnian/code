    public class Foo : IDisposable
    {
      private readonly Socket _socket = new Socket();
      private bool IsDisposed;
      public void Dispose()
      {
        if ( IsDisposed ) return;
        if ( _socket != null )
          _socket.Dispose();
        IsDisposed = true;
      }
      public void method1()
      {
        try
        {
          // some work with _socket
        }
        catch
        {
          throw;
        }
      }
    }
