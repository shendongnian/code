        public struct Point : IEquatable<Point>
    {
        public Point(int x, int y) : this()
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Equals(Point other)
        {
            if (other.X == X && other.Y == Y)
                return true;
            return false;
        }
        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() == typeof(Point))
                return Equals((Point)obj);
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
        public int GetHashCode(Point obj)
        {
            return obj.GetHashCode();
        }
    }
    public class PointComparer : IEqualityComparer<Point>
    {
        public bool Equals(Point x, Point y)
        {
            return x.Equals(y);
        }
        public int GetHashCode(Point obj)
        {
            return obj.GetHashCode();
        }
    }
    public class Tester
    {
        public static List<List<Point>> Dist(List<List<Point>> points)
        {
            var results = new List<List<Point>>();
            var comparer = new PointComparer();
            foreach (var lst in points)
            {
                results.Add(lst.Distinct(comparer).ToList());
            }
            return results;
        }
    }
