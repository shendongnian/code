	public static string GetWeird(string s1, string s2)
	{
		Console.WriteLine(s1);
		for (int i = Math.Max(0, s1.Length - s2.Length); i < s1.Length; i++)
		{
			var ss1 = s1.Substring(i, s1.Length - i);
			var ss2 = s2.Substring(0, Math.Min(s2.Length, ss1.Length));
			Console.WriteLine(ss2.PadLeft(s1.Length));
			if (ss1 == ss2)
				return s1.Substring(0, i);
		}
		return s1;
	}
	public static void Main()
	{
		var s1 = "5675675756756abcdhello";
		var s2 = "hellothere";
		var s3 = GetWeird(s1, s2);
		Console.WriteLine(s3);
	}
