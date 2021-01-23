    class Listener
    {
       private Queue queue;
       public SendMessage(Message m)
       {
         // This will be executed in the calling thread.
         // The locking will be done either in this function or in the Add below
         // depending on your Queue implementation.
         synchronize(this.queue) 
         {
            this.queue.Add(m);
         }
       }
       public Loop()
       {
         // This function should be called from the Listener thread.
         while(true) 
         {
            Message m = this.queue.take();
            doAction(m);
         }
       }
 
       public doAction(Message m)
       {
          if (m is StopMessage)
          {
            ...
          }
       }
    }
