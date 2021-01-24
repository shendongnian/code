    public static string IdAttributeDotReplacement
    {
       get { return WebPages.Html.HtmlHelper.IdAttributeDotReplacement; }
       set { WebPages.Html.HtmlHelper.IdAttributeDotReplacement = value; }
    }
    public static string GenerateIdFromName(string name, string idAttributeDotReplacement)
    {
    	if (name == null)
    	{
    		throw new ArgumentNullException("name");
    	}
    
    	if (idAttributeDotReplacement == null)
    	{
    		throw new ArgumentNullException("idAttributeDotReplacement");
    	}
    
    	// TagBuilder.CreateSanitizedId returns null for empty strings, return String.Empty instead to avoid breaking change
    	if (name.Length == 0)
    	{
    		return String.Empty;
    	}
    
    	return TagBuilder.CreateSanitizedId(name, idAttributeDotReplacement);
    }
