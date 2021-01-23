    public class Observer
    {
        public Observer(Publisher pub)
        {
            pub.SomethingHappened += Publisher_SomethingHappened;
        }
        
        private void Publisher_SomethingHappened(object sender, EventArgs e)
        {
        }
    }
    
    public class Publisher
    {
        public event EventHandler SomethingHappened;
    }
