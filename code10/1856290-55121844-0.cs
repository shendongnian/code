    string FormatLine(string xmlLine)
    {
        var xmlBoldLine = GetFormattedString(xmlLine, "bold");
        var xmlitalicLine = GetFormattedString(xmlBoldLine, "italic");
        return xmlitalicLine;
    }
    string GetFormattedString(string xmlLine, string tag)
    {
        if (xmlLine.Contains(tag))
        {
            return "<" + tag + ">" + xmlLine.Replace(tag, "") + "</" + tag + ">";
        }
        return xmlLine;
    }
