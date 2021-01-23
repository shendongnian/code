    public enum MyEvents{ 
         Event1 
    } 
    public class MyEventArgs : EventArgs
    {
        public MyEventArgs(MyEvents myEvents)
        {
            MyEvents = myEvents;
        }
        public MyEvents MyEvents { get; private set; }
    }
    public static class MyClass
    {
         public static event EventHandler<MyEventArgs> EventTriggered; 
         public static void Trigger(MyEvents myEvents) 
         {
             OnMyEvent(new MyEventArgs(myEvents));
         }
         protected static void OnMyEvent(MyEventArgs e)
         {
             if (EventTriggered != null)
             {
                 // Normally the first argument (sender) is "this" - but your example
                 // uses a static event, so I'm passing null instead.
                 // EventTriggered(this, e);
                 EventTriggered(null, e);
             } 
         }
    }
