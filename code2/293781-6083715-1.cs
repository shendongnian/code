    public static class StringExtensions
    {
    	public static string ToSystemString(this IEnumerable<char> source)
    	{
    		return new string(source.ToArray());
    	}
    }
