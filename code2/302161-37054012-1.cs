    namespace XXX {
      public delegate void Error(string a_sErrorMessage);
      public class XXX {
        public event Error OnError;
        public void Test() {
          try {
            // Do something
          } catch (Exception ex) {
            // Trigger the event
            OnError(ex.Message);
          }
        }
      }
    }
