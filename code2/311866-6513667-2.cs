    public class Foo : IDisposable {
      public void Dispose() {
      }
    }
    
    public class Bar : IDisposable {
      public void Close() {
      }
      void IDisposable.Dispose() {
        Close();
      }
    }
