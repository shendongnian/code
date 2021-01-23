    HtmlDocument doc = new HtmlWeb().Load("http://127.0.0.1");    
    var rows = doc.DocumentNode.SelectNodes("//table[@class='data']/tr");
    foreach (var row in rows)
    {
        var cells = row.SelectNodes("./td");
        string title = cells[0].InnerText;
        var valueRow = cells[2];
        switch (title)
        {
            case "Part-Num":
                string partNum = valueRow.SelectSingleNode("./img[@alt]").Attributes["alt"].Value;
                Console.WriteLine("Part-Num:\t" + partNum);
                break;
            case "Manu-Number":
                string manuNumber = valueRow.SelectSingleNode("./img[@alt]").Attributes["alt"].Value;
                Console.WriteLine("Manu-Num:\t" + manuNumber);
                break;
            case "Description":
                string description = valueRow.InnerText;
                Console.WriteLine("Description:\t" + description);
                break;
            case "Manu-Country":
                string manuCountry = valueRow.InnerText;
                Console.WriteLine("Manu-Country:\t" + manuCountry);
                break;
            case "Last Modified":
                string lastModified = valueRow.InnerText;
                Console.WriteLine("Last Modified:\t" + lastModified);
                break;
            case "Last Modified By":
                string lastModifiedBy = valueRow.InnerText;
                Console.WriteLine("Last Modified By:\t" + lastModifiedBy);
                break;
        }
    }
