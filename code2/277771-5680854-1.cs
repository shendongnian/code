    private EventHandlerList _events = new EventHandlerList();
    private static object MyDelegateKey = new object()
    public event MyDelegate EventName {
      add {
         _events.AddHandler(MyDelegateKey, value);
      }
      remove {
         _events.RemoveHandler(MyDelegateKey, value);
      }
    }
