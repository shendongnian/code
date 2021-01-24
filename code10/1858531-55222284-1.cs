    public static IQueryable<EventModel> ToEventModels(this IQueryable<TsrEvent> tsrEvents)
    {
        return tsrEvent.Select(tsrEvent =>  new EventModel
        {
            Id = tsrEvent.EventId,
            Name = tsrEvent.EventName,
            Capacity = tsrEvent.EventCapacity,
            Active = tsrEvent.EventActive                
        };
    }
