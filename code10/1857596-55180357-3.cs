     var filters = ListResponse.filter.Where(a => a.FLRefID == EvtID).ToList();
        foreach(var tofilter in filters)
        {
            if (tofilter == null)
                continue;
            // The value in tofilter can be empty
            bool bFilterID = string.IsNullOrEmpty(tofilter.FLEventID);
            bool bFilterText = string.IsNullOrEmpty(tofilter.FLText);
            bool bFilterSource = string.IsNullOrEmpty(tofilter.FLSource);
            bool bFilterLevel = string.IsNullOrEmpty(tofilter.FLLevel);
            if(new bool[]{bFilterID, bFilterText, bFilterSource, bFilterLevel}.All(z=>!z)) continue // continue when no filters were set like you wanted
            
    var predicate = PredicateBuilder.False<EventDetails> ();
    if(bFilterID) predicate= predicate.Or(ax => ax.EventID == tofilter.FLEventID);
    if(bFilterText) predicate= predicate.Or(ax => ax.EventMessage.Contains(tofilter.FLText));
    if(bFilterSource) predicate= predicate.Or(ax => ax.EventSourceName == tofilter.FLSource);
    if(bFilterLevel) predicate= predicate.Or(ax => ax.Level == tofilter.FLLevel);
    
            var logs = EventDetails.Where(predicate.Compile());
            string json = JsonConvert.SerializeObject(logs);
        }
