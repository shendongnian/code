    HtmlDocument doc = new HtmlDocument();
    doc.Load(@"C:\Path\To\Page.html");
    HtmlNode radios = doc.SelectNodes("//input[@type=radio]");
    foreach (HtmlNode node in radios)
    {
        HtmlAttribute name = node.Attributes["name"];
        if (name != null && name.ToLower().StartsWith("eq_"))
        {
            //Build your button element and replace the radio using ReplaceChild
        }
    }
