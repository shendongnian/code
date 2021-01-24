    public class Foo
    {
      private Socket _socket { get; }
      public Foo()
      {
        _socket = new Socket();
      }
      ~Foo()
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
