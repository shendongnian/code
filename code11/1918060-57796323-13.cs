	static double ? bounds(double ? a, double ? b, double ? c)
	{
		if (b.HasValue)
		{
			a = a.HasValue ? Math.Max(a.Value, b.Value) : a;
		}
		if (c.HasValue)
		{
			a = a.HasValue ? Math.Min(a.Value, c.Value) : a;
		}
		return a;
	}
