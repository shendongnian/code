        SyndicationFeed feed = new SyndicationFeed("Test Feed", "This is a test feed", new Uri("http://http://example.com/testfeed"), "TestFeedID", DateTime.Now);
        SyndicationItem item = new SyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://example.com/ItemOne"), "TestItemID", DateTime.Now);
        List<SyndicationItem> items = new List<SyndicationItem>();
        items.Add(item);
        feed.Items = items;
        using (XmlWriter xw = XmlWriter.Create(Console.Out, new XmlWriterSettings() { Indent = true }))
        {
            xw.WriteStartDocument();
            xw.WriteProcessingInstruction("xml-stylesheet", "type=\"text/xsl\" href=\"sheet.xsl\"");
            Atom10FeedFormatter atomFormatter = new Atom10FeedFormatter(feed);
            atomFormatter.WriteTo(xw);
            xw.Close();
        }
