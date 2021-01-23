    public static class Messenger<TEventArgs> where TEventArgs : EventArgs {
      private static Dictionary<string, EventHandler<TEventArgs>> eventTable = 
        new Dictionary<string, EventHandler<TEventArgs>>();
      public static void AddListener(string eventType, EventHandler<TEventArgs> handler) {
        if (eventTable.ContainsKey(eventType)) {
          eventTable[eventType] = eventTable[eventType] + handler;
        }
        else {
          eventTable.Add(eventType, handler);
        }
      }
      public static void Invoke(string eventType, TEventArgs args) {
        EventHandler<TEventArgs> d;
        if (eventTable.TryGetValue(eventType, out d)) {
          if (d != null) {
            d(args);
          }
        }
      }
    }
