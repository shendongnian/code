    public class TrackPoint
            {
                public virtual Guid Id { get; set; } = Guid.NewGuid();
                public virtual DateTime Time { get; set; }
                public virtual double DistanceMeters { get; set; }
    
                public TrackPoint GetPreviousByDistance(double Distance, List<TrackPoint> TrackPointsPoints)
                {
                    TrackPoint prevTrackpoint = null;
                    double prevDistance = this.DistanceMeters - Distance;
                    if (prevDistance > 0)
                    {
                        prevTrackpoint = TrackPointsPoints.Where(tp => tp.DistanceMeters < prevDistance).OrderByDescending(tp => tp.DistanceMeters).FirstOrDefault();
                    }
                    return prevTrackpoint;
                }
            }
