	public static void RunSnippet()
	{
		var r = new List<string>();
		Replace("asd_asd_asd_".ToCharArray(), 0, r);
		foreach(var s in r) { Console.WriteLine(s); }
	}
	
	public static char[] possibilities = new char[] { 'A', 'B', 'C' };
	
	public static void Replace(char[] chars, int startIndex, IList<string> result)
	{		
		for (int i = startIndex; i < chars.Length; i++)
		{
			if (chars[i] != '_')
			{
				continue;
			}
			
			// we found first '_'
			for (int j = 0; j < possibilities.Length; j++)
			{
				chars[i] = possibilities[j];
				Replace(chars, i + 1, result);				
			}
			
            chars[i] = '_'; // take back what we replaced
			return; //we're done here
		}
		
		// we didn't find any '_', so all were replaced and we have result:
		result.Add(new string(chars));
	}
