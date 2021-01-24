    public static string GetFeaturesHtml(object o)
    {
        if(o == null || DBNull.Value.Equals(o))
        {
           return "";
        }
        var splittedFeatures= o.ToString().Split(',');
        var sb = new StringBuilder("<ul>");
        foreach(string feature in splittedFeatures)
        {
            sb.Append(string.Format("<li>{0}</li>", feature));
        }
        sb.Append("</ul>");
        return sb.ToString();
    }
