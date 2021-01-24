	static int FirstDiff(string str1, string str2)
	{
		var si1 = StringInfo.GetTextElementEnumerator(str1);
		var si2 = StringInfo.GetTextElementEnumerator(str2);
	
		while (si1.MoveNext() && si2.MoveNext())
			if (!string.Equals(si1.Current as string, si2.Current as string, StringComparison.CurrentCultureIgnoreCase))
				return si1.ElementIndex;
	    return -1; // strings are identical
	}
