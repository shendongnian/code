     HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
     HtmlAgilityPack.HtmlDocument doc = web.Load("http://www.google.com.pk/search?rlz=1C1SKPL_enPK414PK414&sourceid=chrome&ie=UTF-8&q=asd");
    
     foreach (HtmlNode table in doc.DocumentNode.Descendants("table").Where(e => e.GetAttributeValue("id", "").Contains("nav")))
     {
         foreach (HtmlNode row in table.SelectNodes("tr"))
         {
          foreach (HtmlNode cell in row.SelectNodes("th|td"))
          {
              MessageBox.Show("cell: " + cell.InnerHtml);
          }
     }
          
