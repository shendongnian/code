    class MyClass
        {
            event EventHandler myEvent;
    
            public event EventHandler MyEvent
            {
                add { this.myEvent += value.SwallowException(); }
                remove { this.myEvent -= value.SwallowException(); }
            }
    
            protected void OnMyEvent(EventArgs args)
            {
                var e = this.myEvent;
                if (e != null)
                    e(this, args);
            }
        }
    
        public static class EventHandlerHelper
        {
            public static EventHandler SwallowException(this EventHandler handler)
            {
                return (s, args) =>
                {
                    try
                    {
                        handler(s, args);
                    }
                    catch { }
                };
            }
        }
