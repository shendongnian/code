    public class MyClass
    {
       private COMClass instance;
       public event EventHandler<BetterEventArgs> MyBetterEvent;
       public MyClass()
       {
          instance.event += new EventHandler(Handle_COM_event); // ... or whatever
       }
       public void Handle_COM_event(EventArgs)
       {
          if(MyBetterEvent != null) MyBetterEvent(this, new BetterEventArgs());
       }
    }
