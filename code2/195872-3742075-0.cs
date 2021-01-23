    public enum MyEvents { Event1 }
    
    public delegate void MyEventHandler(MyEvents e);
    
    public static event MyEventHandler EventTriggered;
