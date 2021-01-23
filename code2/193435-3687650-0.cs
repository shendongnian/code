    public static IEnumerable<string> Truncater(this IEnumerable<string> s, int len)
	{
		foreach( var str in s )
			{
			if( str.Length > len )
			{
				string outStr = str.Substring(0, len);
				Console.WriteLine(String.Format("Truncated {0} to {1}", str, outStr));
				yield return outStr;
			}
			else
				yield return str;
			}
	}
