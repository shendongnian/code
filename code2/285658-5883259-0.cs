    var html = @"<h2>Some sort of header!</h2>";
    var headers = document.DocumentNode.SelectNodes("//h2|//h3");
    if (headers != null)
    {
        foreach (HtmlNode header in headers)
        {
            var innerText = header.InnerText;
            var idValue = StripTextValue(innerText);
            if (header.Attributes["id"] != null)
            {
                header.Attributes["id"].Value = idValue;
            }
            else
            {
                header.Attributes.Add("id", idValue);
            }
        }
    }
