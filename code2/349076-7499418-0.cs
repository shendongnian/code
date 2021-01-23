    static string GetVehicleInfo(string reg)
    {
        var url = "http://sgwiki.com/wiki/Scania_K230UB_%28Batch_1_Euro_V%29";
        var web = new HtmlAgilityPack.HtmlWeb();
        var doc = web.Load(url);
        var deployments = doc.DocumentNode.SelectNodes("//h2[span/@id='Deployments']/following-sibling::p[1]/b");
        var query = deployments.Where(b => b.InnerText == reg)
            .Select(b => b.InnerText + b.NextSibling.InnerText);
        var content = query.SingleOrDefault();
        return System.Net.WebUtility.HtmlDecode(content);
    }
