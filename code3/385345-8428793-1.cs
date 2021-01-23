    XmlReader Reader = XmlReader.Create("https://gdata.youtube.com/feeds/api/standardfeeds/top_rated");
    SyndicationFeed Feed = SyndicationFeed.Load(Reader);
    foreach (var Item in Feed.Items)
    {
        Console.WriteLine(Item.Title.Text);
        Console.WriteLine(Item.Id);
        Console.WriteLine();
    }
    Reader.Close();
