    public static string GetWierd(string s1, string s2)
    {
       for (int i = 1; i < s1.Length-1; i++)
             if (s1.Substring(s1.Length - i, i) == s2.Substring(0, i))
                return s1.Substring(0, s1.Length - i);
       return null;
    }
	public static void Main()
	{
		var s1 = "abcdhello";
		var s2 = "hellothere";
		var s3 = GetWierd(s1, s2);
		Console.WriteLine(s3);
	}
