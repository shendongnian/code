    SearchServiceApplicationProxy proxy = SearchServiceApplicationProxy.GetProxy(SPServiceContext.Current);
    Guid appId = ssap.GetSearchServiceApplicationInfo().SearchServiceApplicationId;
    SearchServiceApplication app = SearchService.Service.SearchApplications.GetValue<SearchServiceApplication>(appId);
    Content content = new Content(app)
    ContentSource cs = content.ContentSources["<content source name>"];
    cs.StartIncrementalCrawl();
    // check on cs.CrawlStatus if finished 
    
