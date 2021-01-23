    class ObserveEvent_Generic
    {
        public class SomeEventArgs : EventArgs { }
        public static event EventHandler<SomeEventArgs> GenericEvent;
    
        static void Main()
        {
            // To consume GenericEvent as an IObservable:
            IObservable<EventPattern<SomeEventArgs>> eventAsObservable = Observable.FromEventPattern<SomeEventArgs>(
                ev => GenericEvent += ev,
                ev => GenericEvent -= ev );
        }
    }
