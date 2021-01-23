    static void Main(string[] args)
    {
        SyndicationFeed feed = null;
    
        using (var reader = XmlReader.Create("http://stackoverflow.com/feeds"))
        {
            feed = SyndicationFeed.Load(reader);
        }
    
        foreach(var item in feed.Items)
        {
            Console.WriteLine(SerializeItem(item));
        }
    }
    
    private static string SerializeItem(SyndicationItem item)
    {
        var output      = new StringBuilder();
        var formatter   = new Atom10ItemFormatter(item);
    
        using (var writer = XmlWriter.Create(output))
        {
            formatter.WriteTo(writer);
        }
    
        return output.ToString();
    }
