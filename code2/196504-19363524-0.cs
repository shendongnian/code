	public static string Repeat(this string @this, int count)
	{
		var dest = new char[@this.Length * count];
		for (int i = 0, j = 0; i < dest.Length; i += 1, j += 1)
		{
			dest[i] = @this[i % @this.Length];
		}
		return new string(dest);
	}
