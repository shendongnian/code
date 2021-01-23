    Wireup.Init()
    .UsingRavenPersistence("EventStore", new DocumentObjectSerializer())
    .UsingSynchronousDispatcher()
    .PublishTo(new DelegateMessagePublisher(c => PublishMessages(c))
    .Build();
