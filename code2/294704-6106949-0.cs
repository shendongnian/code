    var rssFeed = XDocument.Parse(e.Result);
    var items = from item in rssFeed.Descendants("item")
                select new FeedItemModel()
                        {
                            Title = item.Element("title").Value,
                            DatePublished = DateTime.Parse(item.Element("pubDate").Value),
                            Url = item.Element("link").Value,
                            Description = item.Element("description").Value
                        };
