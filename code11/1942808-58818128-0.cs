      public class Foo : IDisposable {
        Socket _socket;
    
        ...
    
        public void method1() {
          // working with _socket
        }
    
        protected virtual void Dispose(bool disposing) {
          if (disposing) {
            if (_socket != null) {
              _socket.Dispose();
    
              _socket = null;
            }  
          }
        }  
    
        public void Dispose() {
          Dispose(true); 
        }
      }
