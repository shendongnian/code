    public string GetFullHtmlFieldName(string partialFieldName)
    {
        return (this.HtmlFieldPrefix + "." + (partialFieldName ?? string.Empty)).Trim(new char[] { '.' });
    }
    
     
    public string GetFullHtmlFieldId(string partialFieldName)
    {
        return HtmlHelper.GenerateIdFromName(this.GetFullHtmlFieldName(partialFieldName));
    }
