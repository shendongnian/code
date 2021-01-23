	public static string Mix(string s1, string s2)
	{
		if (String.IsNullOrEmpty(s1))
			return s2;
		
		if (String.IsNullOrEmpty(s2))
			return s1;
		
		string s = String.Empty;
		
		for (int i=0; i<Math.Min(s1.Length, s2.Length); i++)
		{
			s += s1[i].ToString() + s2[i].ToString();
		}
		if (s1.Length > s2.Length)
			s += s1.Substring(s2.Length);
		else if (s2.Length > s1.Length)
			s += s2.Substring(s1.Length);
		
		return s;
	}
