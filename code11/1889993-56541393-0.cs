    /// <summary>
    /// Helper method to strip html tags from html
    /// </summary>
    /// <param name="htmlText">raw html</param>
    /// <returns>string without html tags</returns>
    public string StripHTML(string htmlText)
    {
    	Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
    	return reg.Replace(htmlText, "");
    }
