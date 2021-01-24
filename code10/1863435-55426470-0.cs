    using System.Linq;
    using System.Text.RegularExpressions;
    public static int count(string fullString, string searchPattern)
	{
		int i = Regex.Matches(fullString, searchPattern).Cast<Match>().Count();
		return i;
	}
