    IEnumerable<Event> DistinctEventsIncludingSmallestExpiration(IEnumerable<Event> events)
    {
        Event min = null;
        bool minIncludedAlready;
    
        var ids = new HashSet<int>();
        foreach (Event e in events)
        {
            bool isMin = false;
            if (min == null || e.ExpirationTime < min.ExpirationTime)
            {
                min = e;
                isMin = true;
            }
    
            if (ids.Add(e.Id))
            {
                yield return e;
                if (isMin)
                {
                    minIncludedAlready = true;
                }
            }
        }
    
        if (!minIncludedAlready && min != null)
        {
            yield return min;
        }
    }
