    var coordinateList = new List<GeoCoordinate>();
    foreach(var stop in StopsList)
    {
        coordinateList.Add(
            new GeoCoordinate(Convert.ToDouble(stop.LatitudeField),
                              Convert.ToDouble(stop.LongitudeField)));
    }
