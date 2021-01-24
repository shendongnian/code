    public class PieceComparer : IEqualityComparer<Piece>
	{
		public bool Equals(Piece x, Piece y)
		{
			if (object.ReferenceEquals(null, x) && object.ReferenceEquals(null, y)) return true;
			if (object.ReferenceEquals(null, x) || object.ReferenceEquals(null, y)) return false;
			return x.Count == y.Count && x.Date == y.Date && String.Equals(x.Description, y.Description, StringComparison.OrdinalIgnoreCase); // if you want to ignore the case
		}
		public int GetHashCode(Piece p)
		{
			unchecked
			{
				int hash = 17;
				hash = hash * 23 + p.Count;
				hash = hash * 23 + p.Date.GetHashCode();
				hash = hash * 23 + p.Description?.GetHashCode() ?? 0;
				return hash;
			}
		}
	}
