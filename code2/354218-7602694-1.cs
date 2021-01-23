    public static string RemoveHTML(string text)
    {
            text = text.Replace("&nbsp;", " ").Replace("<br>", "\n");
         	var oRegEx = new System.Text.RegularExpressions.Regex("<[^>]+>");
          	return oRegEx.Replace(text, string.Empty);
    }
