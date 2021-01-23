    public class Publisher
    {
        public event EventHandler MyEvent;
        private void RaiseEvent()
        {
            EventHandler handler = MyEvent;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
    public class Subscriber
    {
        public void Subscribe(Publisher pub)
        {
            pub.MyEvent += MethodToCall;
        }
        private void MethodToCall(object sender, EventArgs e)
        {
            // This will be called from Publisher.RaiseEvent
        }
    }
