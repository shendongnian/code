    public class Coordinates : IComparable<Coordinates>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int CompareTo(Coordinates other)
        {
            // If the other instance is null, assume that
            // it is at 0,0?  You need to make that determination.
            if (other == null) return 1;
            // Compare longitude (double implements
            // IComparable<double>.
            int comparison = Longitude.CompareTo(other.Longitude);
            // If not 0, return the value.
            if (comparison <> 0) return comparison;
            // Compare latitude.  Inverse the result, as the more
            // south point (closer to 0) is greater.
            // Just return the value, if they are different, the
            // comparison value will be correct, if they are the
            // same, then comparison will be 0.
            return -Latitude.CompareTo(other.Latitude);
        }
    }
