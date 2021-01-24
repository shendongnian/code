    public class Foo
    {
      Socket _socket;
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
