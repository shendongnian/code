    var combinedList = StopsList.Select(stop =>
        new {
            s = stop,
            coord = new GeoCoordinate(Convert.ToDouble(stop.LatitudeField),
                          Convert.ToDouble(stop.LongitudeField)),
        }).ToList();
