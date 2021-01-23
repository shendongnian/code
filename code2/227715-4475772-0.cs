    public static class MyGlobalEvent {
        public static event EventHandler MyEvent;
    
        public static void FireMyEvent(EventArgs args) 
        {
            var evt = MyEvent;
            if (evt != null)
                evt(args);
        }
    }
