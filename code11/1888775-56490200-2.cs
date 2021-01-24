    private string _htmlFieldPrefix;
    
    public string HtmlFieldPrefix
    {
    	get { return _htmlFieldPrefix ?? String.Empty; }
    	set { _htmlFieldPrefix = value; }
    }
    
    public string GetFullHtmlFieldId(string partialFieldName)
    {
    	return HtmlHelper.GenerateIdFromName(GetFullHtmlFieldName(partialFieldName));
    }
    
    public string GetFullHtmlFieldName(string partialFieldName)
    {
    	// This uses "combine and trim" because either or both of these values might be empty
    	return (HtmlFieldPrefix + "." + (partialFieldName ?? String.Empty)).Trim('.');
    }
