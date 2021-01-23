    Campaign campaign = //get campaign from db
    string id = "Campaigns.Id." + campaign.Id.ToString();
    object old = HttpContext.Current.Cache.Add(
    	id, campaign, null,
    	System.Web.Caching.Cache.NoAbsoluteExpiration,
    	System.Web.Caching.Cache.NoSlidingExpiration,
    	System.Web.Caching.CacheItemPriority.Normal,
    	null);
    if (old == null) {
        // the object was successfully added
    	HttpContext.Current.Cache.Insert(
    		"Campaigns.Code." + campaign.Code, 
    		campaign, 
    		new CacheDependency(null, new [] { id }));
    }
