    IInterface dependency = new Implementation();
    List<IMessageHandler> handlers = new List<IMessageHandler>();
    handlers.Add(new SomeOtherMessageHandler()); 
    handlers.Add(new OrderMessageHandler(dependency));
    MessageProcessor processor = new MessageProcessor(handlers);
    
    processor.ProcessMessage(...);
    //...
