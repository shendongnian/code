    public class RoadComparer : IEqualityComparer<Road>
    {
        public bool Equals(Road x, Road y)
        {
            return x.Id == y.Id;
        }
        public int GetHashCode(Road obj)
        {
            return obj.Id.GetHashCode();
        }
    }
    var results = myRegion.Roads
                          .OfType<Highway>()
                          .Distinct(new RoadComparer())
                          .OrderBy( road => road.Id)
                          .ToList();   
