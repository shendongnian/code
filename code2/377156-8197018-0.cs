    [WebMethod(CacheDuration=86400)]
    public string FunctionName(string Name)
    {
    	...code...
    	return(sb.ToString());
    }
