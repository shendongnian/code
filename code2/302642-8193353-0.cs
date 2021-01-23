    In my case also Facebook feed was difficult to consume and then I try with feedburner to burn the feed for my facebook page. Feedburner generated the feed for me in Atom1.0 format.And then I successfully :) consumed this with system. syndication class
     my code was
    
     string  Main()
        {
            var url = "http://feeds.feedburner.com/Per.........all";
    
                   
            Atom10FeedFormatter formatter = new Atom10FeedFormatter();
            using (XmlReader reader = XmlReader.Create(url))
            {
                formatter.ReadFrom(reader);
            }
            var s = "";
            foreach (SyndicationItem item in formatter.Feed.Items)
            {
                s+=String.Format("[{0}][{1}] {2}", item.PublishDate, item.Title.Text, ((TextSyndicationContent)item.Content).Text);
            }
    
            return s;
        }
