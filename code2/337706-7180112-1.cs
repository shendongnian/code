    var rssFeed = XDocument.Load("http://weblogs.asp.net/scottgu/rss.aspx");
    var posts = from item in rssFeed.Descendants("item")
                select new
                {
                    Title     = (string)item.Element("title"),
                    Published = (DateTime?)item.Element("pubDate"),
                    Url       = (string)item.Element("link"),
                };
