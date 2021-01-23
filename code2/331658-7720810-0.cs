    private static string UrlEncode(IEnumerable<KeyValuePair<string, object>> parameters)
    {
    	StringBuilder parameterString = new StringBuilder();
    	var paramsSorted = from p in parameters
    					   orderby p.Key, p.Value
    					   select p;
    	foreach (var item in paramsSorted)
    	{
    		if (parameterString.Length > 0)
    		{
    			parameterString.Append("&");
    		}
    		if(item.Value.GetType() == typeof(string) )
    				parameterString.Append(
    						string.Format(
    								CultureInfo.InvariantCulture,
    								"{0}={1}",
    								UrlEncode(item.Key),
    								UrlEncode(item.Value as string)));
    	}
    	return UrlEncode(parameterString.ToString());
    }
    public static string UrlEncode(string value)
    {
    	if (string.IsNullOrEmpty(value))
    	{
    		return string.Empty;
    	}
    	value = Uri.EscapeDataString(value);
    	// UrlEncode escapes with lowercase characters (e.g. %2f) but oAuth needs %2F
    	value = Regex.Replace(value, "(%[0-9a-f][0-9a-f])", c => c.Value.ToUpper());
    	// these characters are not escaped by UrlEncode() but needed to be escaped
    	value = value
    		.Replace("(", "%28")
    		.Replace(")", "%29")
    		.Replace("$", "%24")
    		.Replace("!", "%21")
    		.Replace("*", "%2A")
    		.Replace("'", "%27");
    	// these characters are escaped by UrlEncode() but will fail if unescaped!
    	value = value.Replace("%7E", "~");
    	return value;
    }
