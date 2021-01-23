            var nodes = doc.DocumentNode.SelectNodes("//div[@class=\"discount_tools\"]");
            var linksCollections = nodes.Select(node => node.Descendants("a"));
            List<string> Locations = new List<string>();
            List<string> Categories = new List<string>();
            List<string> Hrefs = new List<string>();
            foreach (var col in linksCollections)
            {
                string location, category, href;
                location = GetAtt("data-address",col);
                if (!string.IsNullOrEmpty(location))
                {
                    category = GetAtt("data-kind", col);
                    if (!string.IsNullOrEmpty(category))
                    {
                        href = GetAtt("data-provider", "href", col);
                        if (!string.IsNullOrEmpty(href))
                        {
                            Locations.Add(location);
                            Categories.Add(category);
                            Hrefs.Add(href);
                        }
                    }
                }
            }
