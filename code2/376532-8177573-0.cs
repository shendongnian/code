    public static class Messenger<TEventArgs> where TEventArgs : EventArgs {
      private static Dictionary<string, EventHandler<TEventArgs>> eventTable = 
        new Dictionary<string, EventHandler<TEventArgs>>();
      public static void AddListener(string eventType, EventHandler<TEventArgs> handler) {
        if (!eventTable.ContainsKey(eventType)) {
          eventTable.Add(eventType, handler);
        }
        else {
          eventTable[eventType] = eventTable[eventType] + handler;
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
