    var GetLinks = CrawlPage.ContinueWith(resultTask =>
    {
        if (CrawlPage.Result == null || CrawlPage.Result.DocumentNode == null ||  CrawlPage.Result.DocumentNode.InnerHtml == null)
        {
            return null;
        }
        else
        {
            return ReturnLinks(CrawlPage.Result, srNewCrawledUrl, srNewCrawledPageId);
        }
    
    });
