    public static class Exception {
      public static void Continue(Action action) {
        try {
          action();  
        } catch { 
          // Log 
        }
      }
    }
    
    Exception.Continue(() => Statement1());
    Exception.Continue(() => Statement2());
