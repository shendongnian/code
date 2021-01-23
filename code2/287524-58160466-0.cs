    namespace System {
      public static class ExtensionMethods {
        public static string FullMessage(this Exception ex) {
          var msg = ex.Message.Replace(", see inner exception.", "").Trim();
          if (ex.InnerException != null) msg += " [" + ex.InnerException.FullMessage() + "]";
          return msg;
        }
      }
    }
