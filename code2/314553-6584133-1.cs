    public class MyClass : IMyEvents
    {
        // ...
    
        event EventHandler IMyEvents.MyEvent
        {
            add { MyEvent += value; }
            remove { MyEvent -= value; }
        }
    }
