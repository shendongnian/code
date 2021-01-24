    /// <summary>
    /// Helper method to strip html tags from html
    /// </summary>
    /// <param name="htmlText">raw html</param>
    /// <returns>string without html tags</returns>
    public string StripHTML(string hTMLText)
    {
    	// Remove script and style tags
    	Regex rRemScript = new Regex(@"<(script|style)[^>]*>[\s\S]*?</\1>");
    	hTMLText = rRemScript.Replace(hTMLText, "");
    
    	// Remove link tags AND CONTENTS
    	Regex rRemLink = new Regex(@"<link[\s\S]*?/>");
    	hTMLText = rRemLink.Replace(hTMLText, "");
    
    	// Strip other html tags (leaving contents)
    	Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
    	return reg.Replace(hTMLText, "");
    }
