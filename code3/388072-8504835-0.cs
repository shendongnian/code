    public static class MyExtensions
	{
		public static IList<char> Mismatch(this string str1, string str2)
		{
			var char1 = str1.ToCharArray();
			var char2 = str2.ToCharArray();
			IList<Char> Resultchar= new List<char>();
			for (int i = 0; i < char2.Length;i++ )
			{
				if (i >= char1.Length || char1[i] != char2[i])
					Resultchar.Add(char2[i]);
			}
			return Resultchar;
		}
	}
