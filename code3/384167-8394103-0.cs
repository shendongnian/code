        HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
        HtmlAgilityPack.HtmlDocument doc = web.Load("Yor Path(local,web)"); 
        var result=doc.DocumentNode.SelectNodes("//body//text()");//return HtmlCollectionNode
        foreach(var node in result)
        {
            string AchivedText=node.InnerText;//Your desire text
        }
