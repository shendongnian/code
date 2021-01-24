    private string BuildQueryData(Dictionary<string, object> param)
    {
    	if (param == null )
    		return "";
    
    	StringBuilder b = new StringBuilder();
    	foreach (var item in param)
    	{
    		if (item.Value is string s)
    			b.AppendFormat("&{0}={1}", item.Key, WebUtility.UrlEncode(s));
    		else if (item.Value is Dictionary<string, object> dict)
    			b.Append(BuildQueryData(dict));
    	}
    
    	return b.ToString();
    }
