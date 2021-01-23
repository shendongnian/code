    public class EventRaiser
    {
        public delegate void SomethingHappened();
    
        public event SomethingHappend OnSomethingHappened();
    }
    
    public class Listener
    {
        public void DoSomething()
        {
            //Do something
        }
    }
    public class OtherListener
    {
        public void DoSomethingDifferent()
        {
            //Do something different
        }
    }
    EventRaiser raiser = new EventRaiser();
    Listener listener = new Listener();
    OtherListener other = new OtherListener();
    raiser.OnSomethingHappened += listener.DoSomething;
    raiser.OnSomethingHappened += other.DoSomethingDifferent;
    //This call will call both DoSomething and DoSomethingDifferent
    raiser.OnSomethingHappened();
