    public class Base {
        public event EventHandler<EventArgs> SomeEvent;
        protected virtual void OnSomeEvent(EventArgs e) {
            EventHandler<EventArgs> handler = SomeEvent;
            if (handler != null) {
                handler(this, e);
            }
        }
    }
    public class Derived {
        protected virtual void OnSomeEvent(EventArgs e) {
            // derived event handling here
            // then invoke the base handler
            base.OnSomeEvent(e);
        }
    }
