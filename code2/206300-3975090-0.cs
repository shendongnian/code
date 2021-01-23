    public static class EventUtils {
        public static void SafeInvoke(this EventHandler handler, object sender) {
            if(handler != null) handler(sender, EventArgs.Empty);
        }
        public static void SafeInvoke(this PropertyChangedEventHandler handler,
                   object sender, string propertyName) {
            if(handler != null) handler(sender,
                   new PropertyChangedEventArgs(propertyName));
        }
    }
