    static class StringExtensions
    {
    	public static string PHPIt<T>(this string s, T values, string prefix = "$")
    	{
    		var sb = new StringBuilder(s);
    		foreach(var p in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
    		{
    			sb = sb.Replace(prefix + p.Name, p.GetValue(values, null).ToString());
    		}
    		return sb.ToString();
    	}
    }
