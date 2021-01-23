    public class Bounds
    {
        public Point position;
        public Point size; // I know the width and height don't really compose
                           // a point, but this is just for demonstration
        public override int GetHashCode(){...}
    }
    public class OverlappingBounds : Bounds
    {
        public override bool Equals(object other)
        {
            // your implementation here
        }
    }
    // Usage:
    if (_bounds.ContainsKey(new OverlappingBounds(...))){...}
