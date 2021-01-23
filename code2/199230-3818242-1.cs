    private static string SimpleHtmlCleanup(string html)
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);
    
                //foreach(HtmlNode nodebody in doc.DocumentNode.SelectNodes("//a[@href]"))
    
                var bodyNodes = doc.DocumentNode.SelectNodes("//body");
                if (bodyNodes != null)
                {
                    foreach (HtmlNode nodeBody in bodyNodes)
                    {
                        nodeBody.Attributes.Remove("style"); 
                    }
                }
    
                var scriptNodes = doc.DocumentNode.SelectNodes("//script");
                if (scriptNodes != null)
                {
                    foreach (HtmlNode nodeScript in scriptNodes)
                    {
                        nodeScript.Remove();
                    }
                }
    
                var linkNodes = doc.DocumentNode.SelectNodes("//link");
                if (linkNodes != null)
                {
                    foreach (HtmlNode nodeLink in linkNodes)
                    {
                        nodeLink.Remove();
                    }
                }
    
                var xmlNodes = doc.DocumentNode.SelectNodes("//xml");
                if (xmlNodes != null)
                {
                    foreach (HtmlNode nodeXml in xmlNodes)
                    {
                        nodeXml.Remove();
                    }
                }
    
                var styleNodes = doc.DocumentNode.SelectNodes("//style");
                if (styleNodes != null)
                {
                    foreach (HtmlNode nodeStyle in styleNodes)
                    {
                        nodeStyle.Remove();
                    }
                }
    
                var metaNodes = doc.DocumentNode.SelectNodes("//meta");
                if (metaNodes != null)
                {
                    foreach (HtmlNode nodeMeta in metaNodes)
                    {
                        nodeMeta.Remove();
                    }
                }
               
                var result = doc.DocumentNode.OuterHtml;
                
                return result;
            }
