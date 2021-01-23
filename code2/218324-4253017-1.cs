    public class A
    {
        private EventNotifier eventNotifier;
        public A()
        {
            eventNotifier = new EventNotifier();
            eventNotifier.OnChange += new EventHandler(delegate { MessageBox.Show("Hi"); });
        }
        public void HasChanged()
        {
             eventNotifier.HasChanged = true;
        }
    }
