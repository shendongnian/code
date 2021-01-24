    public List<EventModel> GetEvents(bool showInactive, bool showPastEvents)
    {
        return eventRepository
            .GetEvents(_customerId, showInactive, showPastEvents)
            .Select(ConvertPocoToModelExpr())
            .ToList();
    }
    
    private Expression<Function<TsrEvent,EventModel>> ConvertPocoToModelExpr()
    {
        return (x)=>new EventModel()
        {
            Id = x.EventId,
            Name = x.EventName,
            Capacity = x.EventCapacity,
            Active = x.EventActive                
        };
    }
