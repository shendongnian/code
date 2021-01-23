    string htmlCode = "";
    
                
    
                htmlCode = driver.PageSource.ToString();
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlCode);
    
    var gvTender = doc.DocumentNode.Descendants("table")
                             .Where(table => table.Attributes.Contains("id"))
                             .FirstOrDefault(table => table.Attributes["id"].Value == "ctl00_cphContentArea_gvTenders");
                
                List<HtmlNode> rows = doc.DocumentNode.SelectNodes("//tr").Skip(10).ToList();
                foreach (var row in rows)
                {
                    try
                    {
                        rowCount++;
                        if (rowCount >= 16)
                            break;
    
                        List<HtmlNode> cells = row.SelectNodes("th|td").ToList();
                        
    
                        string s1 = cells[0].InnerText.ToString().Replace("\r\n", "").Trim();
                        string s2 = cells[1].InnerText.ToString().Replace("\r\n", "").Trim();
                        string s3 = cells[2].InnerText.ToString();
                        string s4 = cells[3].InnerText.ToString();
                        string s5 = cells[4].InnerText.ToString();
                        string s6 = cells[5].InnerText.ToString();
                        string s7 = cells[6].InnerText.ToString();
                        string s8 = cells[7].InnerText.ToString();
    
                        
                    }
                    catch (Exception ex)
                    {
     
                    }
                }
    //Developed By -Ramdas Chavan(Datamatics)
