    HtmlDocument doc = new HtmlDocument();
    //remove "option" special handling otherwise inner text won't be parsed correctly
    HtmlNode.ElementsFlags.Remove("option"); 
    doc.Load("test.html");
    var Places = doc.DocumentNode
                    .Descendants("option")
                    .ToDictionary(x => x.InnerText.Split('-')[1].Trim(),
                                  x => x.Attributes["value"].Value);
