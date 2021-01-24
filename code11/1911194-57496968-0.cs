    public EventsController(IEventDBContext context)
    {
        _eventContext = context;
        _eventRepository = new EventRepository(_eventContext);
        _service = new Services.EventService(_eventRepository);
    }
