    public class MyEventArgs : EventArgs
    {
        // any extra info you need can be defined as properties in this class
    }
    
    public event EventHandler<MyEventArgs> MyEvent;
