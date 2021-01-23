    // Register for a specific message type
    Messenger.Default.Register<TypeOfTheMessage>(this, DoSomething);
    ...
    
    // Called when someone sends a message of type TypeOfTheMessage
    private void DoSomething(TypeOfTheMessage message)
    {
        // ...
    }
    // Send a message to all objects registered for this type of message
    Messenger.Default.Send(new TypeOfTheMessage(...));
