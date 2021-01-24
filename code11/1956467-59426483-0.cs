    foreach (var cell in table.SelectNodes(".//tr/td"))
    {
        string someVariable = cell.InnerText;
        Debug.WriteLine(someVariable);
        var links = cell.SelectNodes(".//a");
        if (links == null || !links.Any())
        {
            continue;
        }
 
        foreach (var link in links)
        {
          var href = link.Attributes["href"].Value;
          // do whatever you want with the link.
        }
    }
