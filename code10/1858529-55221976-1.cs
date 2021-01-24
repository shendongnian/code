    public List<EventModel> GetEvents(bool showInactive, bool showPastEvents)
    {
        return eventRepository
            .GetEvents(_customerId, showInactive, showPastEvents)
            .Select(ConvertPocoToModelExpr)
            .ToList();
    }
    
    private static Expression<Func<TsrEvent,EventModel>> ConvertPocoToModelExpr =>  (x)=>new EventModel()
        {
            Id = x.EventId,
            Name = x.EventName,
            Capacity = x.EventCapacity,
            Active = x.EventActive                
        };
