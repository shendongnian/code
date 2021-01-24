var MyTable = Enumerable.FirstOrDefault(htmlDocument.DocumentNode.Descendants("table")
    .Where(table => table.Attributes.Contains("id")), table => table.Attributes["id"].Value == "forecast-table");
    List<HtmlNode> rows = htmlDocument.DocumentNode.SelectNodes("//tr").ToList();
    foreach (var row in rows)
    {
        try
        {
            if (row != null) // Here, it should be row, not My Table along with MyTable in line below.
                Console.WriteLine(row.GetAttributeValue("forecast-table", " "));
        }
        catch (Exception)
        {
        }
    }
You also should know that Html you view by using Dev Tools on chrome is not the same as the one you see in HtmlAgilityPack. Chrome renders the page after executing the scripts where HtmlAgilityPack simply provides you with default HTML of the page. This is the reason why you are not able to get the value of forecast-table.
