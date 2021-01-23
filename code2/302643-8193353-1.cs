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
