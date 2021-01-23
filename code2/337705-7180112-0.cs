    XDocument rssFeed = XDOcument.Load("@http://weblogs.asp.net/scottgu/rss.aspx");
    var posts = from item in rssFeed.Descendants("item")
    select new
    {
        Title = item.Element("title").Value,
        Published = DateTime.Parse(item.Element("pubDate").Value),
        Url = item.Element("link").Value,
    };
