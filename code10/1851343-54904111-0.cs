    public static bool IsObjectsStyleValid<T>(string style, IEnumerable<T> items, Func<T, string> idSelector)
    {
    	foreach (var id in items.Select(idSelector))
    	{
    		if ((style == "decimal" && !Regex.IsMatch(id, "^(\\d*\\.)\\d+"))
    			|| (style == "full" && !Regex.IsMatch(id, "^\\d+$"))
    			|| (style == "numbersWithHalfs" && !Regex.IsMatch(id, "^[1-9][0-9]*\\/[1-9][0-9]*")))
    		{
    			return false;
    		}
    	}
    
    	return true;
    }
