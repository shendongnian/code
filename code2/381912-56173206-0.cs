    string XMLStringWithoutIllegalCharacters(string content)
    {
        if (content.Contains("<"))
            content.Replace("<", "&lt;");
        if (content.Contains(">"))
            content.Replace(">", "&gt;");
        if (content.Contains("\""))
            content.Replace("\"", "&quot;");
        if (content.Contains("&"))
            content.Replace("&", "&amp;");
        if (content.Contains("'"))
           content.Replace("'", "&apos;");
    
        return content;
    }
