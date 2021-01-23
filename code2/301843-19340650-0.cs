    static public class StringExtensions
    {
    	static public string ReplaceInsensitive(this string str, string from, string to)
    	{
    		str = Regex.Replace(str, from, to, RegexOptions.IgnoreCase);
    		return str;
    	}
    }
