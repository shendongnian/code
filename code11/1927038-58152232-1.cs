    public class CustomStringComparer : IComparer<string>
    {
    	private Regex _regex = new Regex(@"By_(?<Tag>[\S]*)",RegexOptions.Compiled);
        public int Compare(string first, string second)
        {
            var firstSubString = _regex.Match(first).Groups["Tag"].Value;
    		var secondSubString = _regex.Match(second).Groups["Tag"].Value;
    		return firstSubString.CompareTo(secondSubString);
        }
    }
