    public class Container
    {
        private WeakReference reference;
        public object Object
        {
            get { return reference.IsAlive ? reference.Target : null; }
            set { reference = new WeakReference(value); }
        }
    }
    public class DelegateTest
    {
        private EventHandler eventHandler;
        private Container container1;
        private Container container2;
        void MyEventHandler(object sender, EventArgs args)
        {
        }
        public DelegateTest()
        {
            this.eventHandler = new EventHandler(MyEventHandler);
            this.container1 = new Container { Object = this.eventHandler };
            this.container2 = new Container { Object = new EventHandler(MyEventHandler) };
            GC.Collect();
            Console.WriteLine("container1: {0}", this.container1.Object == null);
            Console.WriteLine("container2: {0}", this.container2.Object == null);
        }
    }
