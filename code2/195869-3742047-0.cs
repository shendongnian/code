     public enum MyEvents
     { 
        Event1 
     }
    
     public class MyEventArgs : EventArgs
     {
        public MyEvents MyEvent { get; set; }
     }
    
     public static event EventHandler<MyEventArgs> EventTriggered; 
     
     public static void Trigger(MyEvents ev) 
     { 
         if (EventTriggered != null) 
         {
             EventTriggered(null, new MyEventArgs { MyEvent = ev });
         } 
     } 
