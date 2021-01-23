    @foreach (var item in RssFeed().Items)
    {
        <p><a href='@item.Links[0].Uri.OriginalString'><b>@item.Title.Text</b></a></p>
    } 
       
    @functions {
            public SyndicationFeed RssFeed()
              {
                 using (XmlReader reader = XmlReader.Create(ConfigurationManager.AppSettings["RssFeed"]))
                 {
                      return SyndicationFeed.Load(reader);
                 }
              }
            }
