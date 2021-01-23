    using System;
    using System.Text.RegularExpressions;
    
    public static class MyExtensions
    {
    	public static bool Like(this string s, string pattern, RegexOptions options = RegexOptions.IgnoreCase)
        {
            return Regex.IsMatch(s, pattern, options);
        }
    }
