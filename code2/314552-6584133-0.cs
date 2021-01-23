    public class MyClass : IMyEvents
    {
        // ...
    
        event EventHandler IMyEvents.MyEvent
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }
    }
