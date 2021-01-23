     private static string SimpleHtmlCleanup(string html)
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);
    
                //foreach(HtmlNode nodebody in doc.DocumentNode.SelectNodes("//a[@href]"))
    
                foreach(HtmlNode nodebody in doc.DocumentNode.SelectNodes("//body"))
                {
                    nodebody.Attributes.Remove("style");
                }
    
                foreach (HtmlNode nodescripts in doc.DocumentNode.SelectNodes("//script"))
                {
                    nodescripts.Remove();
                }
    
                foreach (HtmlNode nodelink in doc.DocumentNode.SelectNodes("//link"))
                {
                    nodelink.Remove();
                }
    
                foreach (HtmlNode nodexml in doc.DocumentNode.SelectNodes("//xml"))
                {
                    nodexml.Remove();
                }
    
                foreach (HtmlNode nodestyle in doc.DocumentNode.SelectNodes("//style"))
                {
                    nodestyle.Remove();
                }
    
                foreach (HtmlNode nodemeta in doc.DocumentNode.SelectNodes("//meta"))
                {
                    nodemeta.Remove();
                }
                
                var result = doc.DocumentNode.OuterHtml;
                
                return result;
            }
