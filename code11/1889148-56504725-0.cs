    using System.Linq;
    ...
    Dictionary<TrackPoint, TimeSpan> TimeSpans = new Dictionary<TrackPoint, TimeSpan>();
    
    foreach(var trackpoint in trackPointList.Where(x => x.DistanceMeters >= 5000))
    {
        double distance = trackpoint.DistanceMeters;
        foreach(var trackpoint2 in trackPointList.Where(x => x.DistanceMeters < distance))
        {
            if(trackpoint2.DistanceMeters > distance - 5000)
            {
                TimeSpans.Add(trackpoint, trackpoint.Time - trackpoint2.Time);
                break;
            }
        }
    }
