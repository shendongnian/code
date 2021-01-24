    using System.Text.RegularExpressions;
    public static int count(string fullString, string searchPattern)
	{
		int i = Regex.Matches(fullString, searchPattern).Count;
		return i;
	}
