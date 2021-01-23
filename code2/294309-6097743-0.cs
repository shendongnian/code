     internal class RssItem
        {
            public DateTime Date;
            public string Title;
            public string Description;
            public string Link;
        }
    XmlDocument xmlDoc = new XmlDocument();
    private Collection<RssItem> feedItems = new Collection<RssItem>();
    xmlDoc.Load("URL of the RSS Feeds");
    ParseRssItems(xmlDoc);
    private void ParseRssItems(XmlDocument xmlDoc)
            {
                this.feedItems.Clear();
                foreach (XmlNode node in xmlDoc.SelectNodes("rss/channel/item"))
                {
                    RssItem item = new RssItem();
                    this.ParseDocElements(node, "title", ref item.Title);
                    this.ParseDocElements(node, "description", ref item.Description);
                    this.ParseDocElements(node, "link", ref item.Link);
                    string date = null;
                    this.ParseDocElements(node, "pubDate", ref date);
                    DateTime.TryParse(date, out item.Date);
                    this.feedItems.Add(item);
                }
            }
