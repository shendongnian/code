    private DispatchStopModel FindClosestStop(DispatchStopModel start, 
        ICollection<DispatchStopModel> stops)
    {
        DispatchStopModel closest = null;
        // other code ommitted for brevity
        if (distanceTo < start.Distance)
        {
            start.Distance = distanceTo;
            start.NextDispatchID = stop.OrderDispatchID;
            closest = stop;
        }
        // other code ommitted for brevity
        return closest;
    }
