    // define the delegate
    public delegate void CustomEventHandler(object sender, CustomEventArgs e);
    // define the event args
    public class CustomEventArgs : EventArgs
    {
         public int SomeValue { get; set; }
         public CustomEventArgs( int someValue )
         {
             this.SomeValue = someValue;
         }
    }
    // Define the class that is raising events
    public class SomeClass
    {
        // define the event
        public event CustomEventHandler CustomEvent;
        // method that raises the event - derived classes can override this
        protected virtual void OnCustomEvent(CustomEventArgs e)
        {
            // do some stuff
            // ...
            
            // fire the event
            if( CustomEvent != null )
                CustomEvent(this, e);
        }
        public void SimulateEvent(int someValue)
        {
            // raise the event
            CustomEventArgs args = new CustomEventArgs(someValue);
            OnCustomEvent(args);
        }
    }
    public class Main
    {
        public static void Main()
        {
            SomeClass c = new SomeClass(); 
            c.CustomEvent += SomeMethod;
            c.SimulateEvent(10); // will cause event
        }
        public static void SomeMethod(object sender, CustomEventArgs e)
        {
             Console.WriteLine(e.SomeValue);
        }
    }
