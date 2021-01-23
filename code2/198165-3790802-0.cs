    /// <summary>
    /// Converts an Html string to plain text, and replaces all br tags with line breaks.
    /// </summary>
    /// <returns></returns>
    /// <remarks></remarks>
    [Extension()]
    public string ToPlainText(string s)
    {
    
    	s = s.Replace("<br>", Constants.vbCrLf);
    	s = s.Replace("<br />", Constants.vbCrLf);
    	s = s.Replace("<br/>", Constants.vbCrLf);
    
    
    	s = Regex.Replace(s, "<[^>]*>", string.Empty);
    
    
    	return s;
    }
