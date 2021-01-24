csharp
private static string foo()
{
    var htmlDoc = new HtmlDocument();
    htmlDoc.LoadHtml("<div><p class=\"ok\">text</p></div>");
    var pNodes = htmlDoc.DocumentNode.SelectNodes("//p");
    foreach (var node in pNodes)
    {
        node.Attributes.Remove();
    }
    return htmlDoc.DocumentNode.WriteTo();
}
