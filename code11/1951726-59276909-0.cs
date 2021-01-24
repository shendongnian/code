    var myCancellationToken = new CancellationTokenSource();
	crawler.CrawlAsync(someUri, myCancellationToken);
    
	private static void PageCrawlCompleted(object sender, PageCrawlCompletedArgs e)
	{
		//More performant (since the parsing has already been done by Abot)
		var hasAmazonLinks = e.CrawledPage.ParsedLinks
          .Any(hl => hl.HrefValue.AbsoluteUri
             .ToLower()
             .Contains("amazon.com"));
		
		if (hasAmazonLinks)
		{
            //LOG SOMETHING BEFORE YOU STOP THE CRAWL!!!!!
			//Option A: Preferred method, Will clear all scheduled pages and cancel any threads that are currently crawling
			myCancellationToken.Cancel();
			//Option B: Same result as option A but no need to do anything with tokens. Not the preferred method. 
			e.CrawlContext.IsCrawlHardStopRequested = true;
			//Option C: Will clear all scheduled pages but will allow any threads that are currently crawling to complete. No cancellation tokens needed. Consider it a soft stop to the crawl.
			e.CrawlContext.IsCrawlStopRequested = true;
		}
	}
