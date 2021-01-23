    public static class SingleParameterMessenger<TEventArgs> {
        public static void Invoke(string eventType, TEventArgs args) {
            Messenger<SingleParameterArgs<TEventArgs>>.Invoke(eventType, args);
        }
    }
