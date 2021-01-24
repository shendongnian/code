    using HtmlAgilityPack;
    HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml("<td class=\"NumberCell\" width=\"60\">2</td>");
    
                foreach (HtmlNode node in doc.DocumentNode.SelectNodes("td"))
                {
                    Console.WriteLine("text=" + node.InnerText);
                }
 
