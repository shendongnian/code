    public static class GlobalMessages {
        public static void Register(IGlobalNotification listener) {
            listener.Disposed += delegate { listeners.Remove(listener); };
            listeners.Add(listener);
        }
        public static void Notify(MyEventArgs arg) {
            foreach (var listener in listeners) listener.OnMessage(arg);
        }
        private static List<IGlobalNotification> listeners = new List<IGlobalNotification>();
    }
