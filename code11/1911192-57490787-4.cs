     private readonly Services.IEventService _service;
    
    public EventsController(IEventService service)
    {
        _service = service;
    }
