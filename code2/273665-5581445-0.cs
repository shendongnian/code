	public struct Pair : IComparable<Pair>, IEquatable<Pair>
	{
		private readonly int x;
		private readonly int y;
		
		public Pair(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
		public int X { get { return x; } }
		public int Y { get { return y; } }
		public int CompareTo(Pair other)
		{
			return (x == other.x) ? y.CompareTo(other.y) : x.CompareTo(other.x);
		}
		public bool Equals(Pair other)
		{
			return x == other.x && y == other.y;
		}
	}
