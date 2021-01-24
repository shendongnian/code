    public class MessageProcessor {
        private List<IMessageHandler> handlers;
    
        public MessageProcessor(IEnumerable<IMessageHandler> handlers) {
            this.handlers = new List<IMessageHandler>(handlers);
            //removed
            //handlers.add(new SomeOtherMessageHandler()); 
            //handlers.add(new OrderMessageHandler());
        }
    
        public void ProcessMessage( IMessage msg ) {
           bool messageWasHandled
           foreach( IMessageHandler handler in handlers ) {
               if ( handler.HandleMessage(msg) ) {
                   messageWasHandled = true;
                   break;
               }
           }
    
           if ( !messageWasHandled ) {
              // Do some default processing, throw error, whatever.
           }
        }
    }
