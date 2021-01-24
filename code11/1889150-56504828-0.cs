    var trackPointList = new List<TrackPoint>
    {
        new TrackPoint {Time = DateTime.Parse("2018-08-10 07:17:48"), DistanceMeters = 3.8099999427795410},
        // ...
        new TrackPoint {Time = DateTime.Parse("2018-08-10 07:24:04"), DistanceMeters = 5003.4101562500000000}, //5000 meters driven
        // ...
        new TrackPoint {Time = DateTime.Parse("2018-08-10 07:30:04"), DistanceMeters = 10003.4101562500000000}, //10000 meters driven
    };
    // determine how many marks you have according to the highest value recorded
    int pointsCount = (int)trackPointList[trackPointList.Count - 1].DistanceMeters % 5000;
    var lastPoint = trackPointList[0];
    for (int i = 1; i < pointsCount; i++)
    {
        double point = i * 5000;
        // find the closest to the current mark
        var currentPoint = trackPointList.Where(x => x.DistanceMeters > point).First();
        Console.WriteLine("At {0}, you have driven {1}, {2} for the past 5KM", currentPoint.Time, currentPoint.DistanceMeters, currentPoint.Time - lastPoint.Time);
        lastPoint = currentPoint;
    }
