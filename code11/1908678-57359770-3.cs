    public static bool IsEqualsTo<T>(T o, params T[] p)
	{
		var comparer = EqualityComparer<T>.Default; // make it an optional parameter
		for (int i = 0; i < p.Length; i++)
		{
			if (comparer.Equals(o, p[i]))
				return true;
		}
		return false;
	}
