    class EventConsumer{
      private EventEmitter x = new EventEmitter();
      public EventConsumer() {
         x.MyEvent += new MyDel(this.MyEventHandler);
         x.MyEvent += new MyDel(this.MyEventHandler2);
      }
      
      public string MyEventHandler(string username) {
         return "Welcome " + username;
      }
      public string MyEventHandler2(string username) {
         return "Goodbye " + username;
      }
    }
