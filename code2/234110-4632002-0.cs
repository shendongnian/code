    static string EscapeQuotes(this string str)
    {
        return str.Replace("\"", "\\\"");
    }
    static IAttrDict ToDictionary(this object obj)
    {
        return obj.GetType().GetProperties().Where(prop => prop.CanRead).ToDictionary(prop => prop.Name, prop => prop.GetValue(obj, null));
    }
    static string HtmlTag(string tagName, string content = null, object attrs = null)
    {
        IAttrDict attrDict = attrs != null ? attrs is IAttrDict ? (IAttrDict)attrs : attrs.ToDictionary() : null;
        var sb = new StringBuilder("<");
        sb.Append(tagName);
        if(attrDict != null)
            foreach (var attr in attrDict)
                sb.AppendFormat(" {0}=\"{1}\"", attr.Key, attr.Value.ToString().EscapeQuotes());
        if (content != null) sb.AppendFormat(">{0}</{1}>", content, tagName);
        else sb.Append(" />");
        return sb.ToString();
    }
