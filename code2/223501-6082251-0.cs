    public delegate void MyEventHandler(object Sender, EventArgs Args);
    public class MyMain
    {
         public event MyEventHandler MyEvent;
         ...
         new MyExternal(this.MyEvent);
         ...
    }
    public MyExternal
    {
         private MyEventHandler MyEvent;
         public MyExternal(MyEventHandler MyEvent)
         {
               this.MyEvent = MyEvent;
         }
         ...
         this.MyEvent(..., ...);
         ...
    }
