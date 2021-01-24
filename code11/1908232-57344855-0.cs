    var inputHtml = _webBrowser
        .Document
        .GetElementsByTagName("input")
        .Cast<HtmlElement>()
        .Single()
        .OuterHtml;     
    var elementHtmlDoc = new HtmlAgilityPack.HtmlDocument();
    elementHtmlDoc.LoadHtml(inputHtml);
    var attributesDictionary = elementHtmlDoc
        .DocumentNode
        .ChildNodes
        .Single()
        .Attributes
        .ToDictionary(
            attr => attr.Name, 
            attr => attr.Value);
    MessageBox.Show(
        String.Join(Environment.NewLine, attributesDictionary),
        "Attributes");
