    // Here TEventArgs represents the element type *within* SingleParameterArgs
    public static class Messenger<TEventArgs> {
        private static
            Dictionary<string, EventHandler<SingleParameterArgs<TEventArgs>> eventTable = 
                new Dictionary<string, EventHandler<SingleParameterArgs<TEventArgs>>();
        public static void Invoke(string eventType, TEventArgs args) {
            EventHandler<SingleParameterArgs<TEventArgs>> eventHandler;
            if (eventTable.TryGetValue(eventType, out eventHandler)) {          
                if (eventHandler != null) {
                    eventHandler();
                }
            }
        }
    }
