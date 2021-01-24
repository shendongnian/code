    const string indexName = "bla";
    var client = GetClient(indexName);
    const int scrollTimeout = 1000;
    
    var initialResponse = client.Search<Document>
    	(scr => scr.Index(indexName)
    	.From(0)
    	.Take(100)
    	.MatchAll()
    	.Scroll(scrollTimeout))
    ;
    
    List<XYZ> results;
    results = new List<XYZ>();
    
    if (!initialResponse.IsValid || string.IsNullOrEmpty(initialResponse.ScrollId))
    throw new Exception(initialResponse.ServerError.Error.Reason);
    
    if (initialResponse.Documents.Any())
    results.AddRange(initialResponse.Documents);
    
    var scrollid = initialResponse.ScrollId;
    bool isScrollSetHasData = true;
    while (isScrollSetHasData)
    {
    	var loopingResponse = client.Scroll<XYZ>(scrollTimeout, scrollid);
    
    	if (loopingResponse.IsValid)
    	{
    	    results.AddRange(loopingResponse.Documents);
    	    scrollid = loopingResponse.ScrollId;
    	}
    	isScrollSetHasData = loopingResponse.Documents.Any();
    
    	// do some amazing stuff
    }
    
    client.ClearScroll(new ClearScrollRequest(scrollid));
