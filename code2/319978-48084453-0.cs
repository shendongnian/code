	    public static string Truncate(this string value, int maxChars)
	    {
	        const string ellipses = "...";
	        return value.Length <= maxChars ? value : value.Substring(0, maxChars - ellipses.Length) + ellipses;
	    }
