	public static bool EqualsIgnoreCase(char c1, char c2)
	{
		var culture = System.Globalization.CultureInfo.CurrentCulture;
		return Char.ToLower(c1, culture) == Char.ToLower(c2, culture);
	}
	public static bool IsPalindrome(string s)
	{	
		switch (s?.Length ?? 0)
		{
			case 0:
				return false;
			case 1:
				return true;
			case 2:
				return EqualsIgnoreCase(s[0], s[1]);
			case 3:
				return EqualsIgnoreCase(s[0], s[2]);
		}
		var firstIndex = 0;
		var lastIndex = s.Length - 1;
        // todo: this probably falls on its face for a string with only non-letters
		do
		{
			while (!Char.IsLetter(s[firstIndex]))
				++firstIndex;
			while (!Char.IsLetter(s[lastIndex]))
				--lastIndex;
			if (!EqualsIgnoreCase(s[firstIndex++], s[lastIndex--]))
				return false;
				
		} while (firstIndex < lastIndex);
		return true;
	}
