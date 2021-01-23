    public class Comparer : IEqualityComparer<Point>
		{
			public bool Equals(Point x, Point y)
			{
				return x.X == y.X;
			}
			public int GetHashCode(Point obj)
			{
				return (int)obj.X;
			}
		}
