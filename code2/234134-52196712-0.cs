	public static Match[] Matches(this Regex rx, String s, int ix, int c)
	{
		if ((ix | c) < 0 || ix + c > s.Length)
			throw new ArgumentException();
		int i = 0;
		var rg = Array.Empty<Match>();
		Match m;
		while (c > 0 && (m = rx.Match(s, ix, c)).Success)
		{
			if (i == rg.Length)
				Array.Resize(ref rg, (i | 1) << 1);
			rg[i++] = m;
			c += ix - (ix = m.Index + m.Length);
		}
        if (i < rg.Length)
		    Array.Resize(ref rg, i);
		return rg;
	}
