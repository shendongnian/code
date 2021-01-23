    HtmlElement btn = myBrowserControl.Document.GetElementById("myButton");
    /*
    Alternatively, take a look at these other methods for retrieving an HtmlElement:
    HtmlDocument.GetElementFromPoint(Point point)
    HtmlDocument.GetElementsByTagName(string tagName)
    HtmlDocument.All.GetElementsByName(string name)
    */
    btn.InvokeMember("click");
