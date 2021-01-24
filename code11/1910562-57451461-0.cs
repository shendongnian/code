    public static class StringExts
    {
    	public static string CutStringIfNeeded(this string value, int maxCount)
    	{
    		return (!string.IsNullOrWhiteSpace(value) && value.Length >= maxCount)
    				   ? value.Substring(0, maxCount - 1)
    				   : value;
    	}
    }
