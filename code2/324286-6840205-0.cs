    void ProcessMessage(dynamic message)
    {
        // This will call the generic method with the right
        // type for T inferred from the actual type of the object
        // message refers to.
        ProcessMessageImpl(message);
    }
    void ProcessMessageImpl<T>(T message)
    {
        Handler<T> handler = (Handler<T>) handlers[typeof(T)];
        handler.ProcessMessage(message);
    }
