    HtmlDocument htmlDoc = new HtmlDocument();
    htmlDoc.LoadHtml(html);
    foreach (HtmlNode table in htmlDoc.DocumentNode.SelectNodes("//div[@class='boardcontainer']/table"))
    {
      Console.WriteLine("Found: " + table.Id);
                                
      foreach (HtmlNode row in table.SelectNodes("tr"))
      {
        Console.WriteLine("row");
   
        HtmlNodeCollection cells = row.SelectNodes("th|td");
        if (cells == null)
        {
          continue;
        }
        foreach (HtmlNode cell in cells)
        {                        
          Console.WriteLine("cell: " + cell.InnerText);
        }
      }
    } 
