        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.Load(yourHtml);
        foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//img"))
        {
            Console.WriteLine(HtmlEntity.DeEntitize(node.NextSibling.InnerText).Trim());
        }
