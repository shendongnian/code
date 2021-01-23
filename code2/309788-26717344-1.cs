    class ObserveEvent_NonGeneric
    {
        public class SomeEventArgs : EventArgs { }
        public delegate void SomeNonGenericEventHandler(object sender, SomeEventArgs e);
        public static event SomeNonGenericEventHandler NonGenericEvent;
    
        static void Main()
        {
            // To consume NonGenericEvent as an IObservable, first inspect the type of EventArgs used in the second parameter of the delegate.
            // In this case, it is SomeEventArgs.  Then, use as shown below.
            IObservable<IEvent<SomeEventArgs>> eventAsObservable = Observable.FromEvent(
                (EventHandler<SomeEventArgs> ev) => new SomeNonGenericEventHandler(ev), 
                ev => NonGenericEvent += ev,
                ev => NonGenericEvent -= ev);
        }
    }
