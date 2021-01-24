    List<DispatchStopModel> deliveries = deliveryService.GetYourDeliveries();
    List<DispatchStopModel> temp = deliveries.ToList();
    // Assuming you have a start location
    DispatchStopModel start = GetStartingPoint();
    // Assign the closest stop to it
    FindClosestStop(start, deliveries);
    // Now assign the closest delivery for each of the rest
    // of the items, removing the closest item on each
    // iteration, so it doesn't get assigned more than once.
    foreach (var delivery in deliveries)
    {
        var closest = FindClosestStop(delivery, temp);
        temp.Remove(closest);
    }
