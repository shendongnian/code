    IEnumerable<Event> DistinctEvents(IEnumerable<Event> events)
    {
        var dict = new Dictionary<int, Event>();
    
        foreach (Event e in events)
        {
            Event existing;
            if (!dict.TryGetValue(e.Id, out existing) || e.ExpirationTime < existing.ExpirationTime)
            {
                dict[e.Id] = e;
            }
        }
    
        foreach (Event e in dict.Values)
        {
            yield return e;
        }
    }
