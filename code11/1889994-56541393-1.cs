    /// <summary>
    /// Helper method to strip html tags from html
    /// </summary>
    /// <param name="htmlText">raw html</param>
    /// <returns>string without html tags</returns>
    public string StripHTML(string hTMLText)
    {
    	// Remove script content
    	Regex rRemScript = new Regex(@"<script[^>]*>[\s\S]*?</script>");
    	hTMLText = rRemScript.Replace(hTMLText, "");
    
    	// Remove link content
    	Regex rRemLink = new Regex(@"<link[^>]*>[\s\S]*?</link>");
    	hTMLText = rRemLink.Replace(hTMLText, "");
    
    	// Remove style content
    	Regex rRemStyle = new Regex(@"<style[^>]*>[\s\S]*?</style>");
    	hTMLText = rRemStyle.Replace(hTMLText, "");
    
    	// Just strip the tags from the rest
    	Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
    	return reg.Replace(hTMLText, "");
    }
