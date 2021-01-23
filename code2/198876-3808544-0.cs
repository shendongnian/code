                var feed = new SyndicationFeed();
            var items = new List<SyndicationItem>();
            foreach (var item in rssItems)
            {
                var syndicationItem = new SyndicationItem
                {
                    Title = item.Title,
                    Content = item.Description,
                    PublishDate = item.PublishDate,
                };
                syndicationItem.ElementExtensions.Add(new XElement("image", item.Image));
                syndicationItem.AddPermalink(new Uri(item.Link));
                items.Add(syndicationItem);
            }
            feed.Items = items;
            using (var xml = new XmlTextWriter(Response.OutputStream, Encoding.UTF8))
            {
                feed.SaveAsRss20(xml);
            }
