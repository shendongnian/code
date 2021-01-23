    List<string> result = new List<string>();
    foreach (HtmlNode link in document.DocumentNode.SelectNodes("//img[@src]"))
    {
        HtmlAttribute att = link.Attributes["src"];
        string temp = att.Value;
        string urlValue;
        do
        {
            urlValue = temp;
            temp = HttpUtility.UrlDecode(HttpUtility.HtmlDecode(urlValue));
        } while (temp != urlValue);
        result.Add(temp);
    }
