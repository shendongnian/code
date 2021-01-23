    public static string RemoveHTML(string text)
    {
        text = text.Replace("&nbsp;", " ").Replace("<br>", "\n").Replace("description", "").Replace("INFRA:CORE:", "")
            .Replace("RESERVED", "")
            .Replace(":", "")
            .Replace(";", "")
            .Replace("-0/3/0", "");
            var oRegEx = new System.Text.RegularExpressions.Regex("<[^>]+>");
            return oRegEx.Replace(text, string.Empty);
    }
