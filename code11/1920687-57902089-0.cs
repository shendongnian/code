    var HTMLCode = "This is<p>ADP</p>";
    var result = System.Text.RegularExpressions.Regex
        .Replace(HTMLCode, "<p>", " ")
        .Replace("<[^>]*>", "")
        .Replace("</p>",string.Empty);
