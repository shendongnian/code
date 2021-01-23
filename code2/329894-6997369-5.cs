    public sealed class Thing {
      public readonly ManualResetEvent ManualResetEvent = new ManualResetEvent(false);
    
      private void TheAction() {
        ...
        // Done.  Signal the listeners
        ManualResetEvent.Set();
      }
    }
