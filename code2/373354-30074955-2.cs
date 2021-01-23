    public static class StringExtensions
    {
    	/// <summary>
    	/// Cut End. "12".SubstringFromEnd(1) -> "1"
    	/// </summary>
    	public static string SubstringFromEnd(this string value, int startindex)
    	{
    		if (string.IsNullOrEmpty(value)) return value;
    		return value.Substring(0, value.Length - startindex);
    	}
    }
