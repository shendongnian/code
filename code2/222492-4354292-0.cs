    var top3 = new List<string>();
    foreach (var manufacturer in allCarsOrderedFastestToSlowest
                                    .Select(car=>car.Manufacturer))
    {
        if (!top3.Contains(manufacturer))
        {
            top3.Add(manufacturer);
            if (top3.Count == 3)
            {
                break;
            }
        }
    }
