    public delegate void Eventhandler(object sender, EventArgs args);
    // your publishing class
    class Foo
    {
        public event EventHandler Changed;    // the Event
        protected virtual void OnChanged()    // the Trigger method, called to raise the event
        {
            // make a copy to be more thread-safe
            EventHandler handler = Changed;
            if (handler != null)
            {
                // invoke the subscribed event-handler(s)
                handler(this, EventArgs.Empty);
            }
        }
        // an example of raising the event
        public void SomeMethod()
        {
            
                OnChanged();  // raise the event
        }
    }
    
    public class Program
    {
        static void Main(string[] args)
        {
            Foo objFoo = new Foo();
            objFoo.Changed += ObjFoo_Changed;
            objFoo.SomeMethod();
            Console.ReadLine();
        }
        private static void ObjFoo_Changed(object sender, EventArgs e)
        {
            Console.WriteLine("Event fired and changed");
        }
    }
  }
