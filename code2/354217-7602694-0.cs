    public static string RemoveHTML(string text)
    {
         	var oRegEx = new System.Text.RegularExpressions.Regex("<[^>]+>");
          	return oRegEx
                 .Replace(text, string.Empty)
                 .Replace("&nbsp;", " ")
                 .Replace("<br>", "\n");
    }
