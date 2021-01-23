    HtmlNodeCollection tl = document.DocumentNode.SelectNodes("//p[not(@*)]");
    foreach (HtmlAgilityPack.HtmlNode node in tl)
    {
        Console.WriteLine(node.InnerText.Trim());
    }
