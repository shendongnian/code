    const string url = "http://www.rwth-aachen.de/go/id/yvu/scol/1/sasc/1/pl/313";
    const string kml = "http://www.adress.xy/file.kml";
    var newKml = new[] { kml };
    var web = new HtmlWeb();
    var doc = web.Load(url);
    var xpath = "//table[@style='table-layout:auto']/tr[td]";
    var rows = doc.DocumentNode.SelectNodes(xpath);
    var table = rows
        .Select(row =>
            row.Elements("td")
               .Skip(1)
               .Take(4)
               .Select(col => System.Net.WebUtility.HtmlDecode(col.InnerText))
               .Concat(newKml)
               .ToList()
        ).ToList();
