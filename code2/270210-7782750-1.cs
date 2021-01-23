    var web = new HtmlWeb();
    var doc = web.Load("http://gtin13.com/query.jsp?query=Hunts");
    var sections = doc.DocumentNode.SelectNodes("//div[@class='PostContent']/b");
    var result = new List<Data>();
    foreach (var header in sections)
    {
        var data = new Data();
        data.Name = header.InnerText.Trim();
        var currentField = header.NextSibling.NextSibling;
        var sizeMatch = Regex.Match(currentField.InnerText.Trim(), @"Size: (.+)");
        if (sizeMatch.Success)
        {
            data.Size = sizeMatch.Groups[1].Value;
            currentField = currentField.NextSibling.NextSibling;
        }
        var gtinMatch = Regex.Match(currentField.InnerText.Trim(), @"GTIN/EAN-13: (\S+) / (\S+)");
        if (gtinMatch.Success)
        {
            data.Gtin = gtinMatch.Groups[1].Value;
            data.Ean13 = gtinMatch.Groups[2].Value;
            currentField = currentField.NextSibling.NextSibling;
        }
        var upcMatch = Regex.Match(currentField.InnerText.Trim(), @"UPC-A: (\S+) / (\S+)");
        if (upcMatch.Success)
        {
            data.Upc = upcMatch.Groups[1].Value;
            data.UpcA = upcMatch.Groups[2].Value;
        }
        result.Add(data);
    }
