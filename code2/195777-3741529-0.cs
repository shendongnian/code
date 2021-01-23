    [HttpGet, ChildActionOnly]
    // put this in RssController
    public ActionResult RssFeed()
    {
    	// prepare the model
    	SyndicationFeed rssData;
    	using (XmlReader reader = XmlReader.Create(ConfigurationManager.AppSettings["RssFeed"])) 
    	{
    		rssData = SyndicationFeed.Load(reader);
    	}
    
    	return PartialView(rssData);
    }
