    static void Main(string[] args)
    {
        Atom10FeedFormatter formatter = new Atom10FeedFormatter();
        using (XmlReader reader = XmlReader.Create("http://latestpackagingnews.blogspot.com/feeds/posts/default"))
        {
            formatter.ReadFrom(reader);
        }
        foreach (SyndicationItem item in formatter.Feed.Items)
        {
            Console.WriteLine("[{0}][{1}] {2}", item.PublishDate, item.Title.Text, ((TextSyndicationContent)item.Content).Text);
        }
        Console.ReadLine();
    }
