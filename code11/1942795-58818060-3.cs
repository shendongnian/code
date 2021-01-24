    public class Foo : IDisposable
    {
      private readonly Socket _socket = new Socket();
      public void Dispose()
      {
        _socket.Dispose();
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
