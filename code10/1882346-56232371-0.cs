	public struct PointComparer : IEqualityComparer<(float x, float y)>
	{
		public bool Equals((float x, float y) p1, (float x, float y) p2)
		{
			return Math.Abs(p1.x - p2.x) < 1f && Math.Abs(p1.y - p2.y) < 1f;
		}
		public int GetHashCode((float x, float y) obj)
		{
			return obj.GetHashCode();
		}
	}
