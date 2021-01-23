    var items = doc.Descendants("item")
                   .Select(c =>
                   {
                        string descriptionHtml = c.Element("description").Value;
                        HtmlDocument descriptionDoc = new HtmlDocument();
                        descriptionDoc.LoadHtml(descriptionHtml);
                        HtmlNode imageNode = doc.DocumentNode.SelectSingleNode("//img[@src]");
                        string imageUrl = (imageNode != null)
                            ? imageNode.GetAttributeValue("src", null)
                            : null;
                        // This might need further looking at, depending on your HTML
                        string description = doc.DocumentNode.InnerText;
                        return new RSSitem() 
                        { 
                            Title = c.Element("title").Value, 
                            Photo = imageUrl, 
                            Description = description, 
                            Link = c.Element("link").Value, 
                        };
                   }).ToList();
