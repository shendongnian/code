    using System;
    public delegate string MyDel(string str);
    
    class EventEmitter {
      event MyDel MyEvent;
    }
    
    class EventConsumer{
      private EventEmitter x = new EventEmitter();
      public EventConsumer() {
         x.MyEvent += new MyDel(this.MyEventHandler);
      }
      
      public string MyEventHandler(string username) {
         return "Welcome " + username;
      }
    }
    
