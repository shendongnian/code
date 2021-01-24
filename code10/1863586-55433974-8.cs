    Events[EventTypes.Event1] += (object data) =>
    {
        Console.WriteLine($"Event1 first handler: {data}");
    };
    Events[EventTypes.Event1] += (object data) =>
    {
        Console.WriteLine($"Event1 second handler: {data}");
    };
    Events[EventTypes.Event2] += (object data) =>
    {
        Console.WriteLine($"Event2 handler: {data}");
    };
    Events[EventTypes.Event1].Invoke("test1");
    Events[EventTypes.Event2].Invoke("test2");
    Events[EventTypes.Event3].Invoke("test3");
