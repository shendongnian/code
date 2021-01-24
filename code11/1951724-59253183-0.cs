    var pageRequester = new PageRequester(new CrawlConfiguration(), new WebContentExtractor());
    var crawledPage = await pageRequester.MakeRequestAsync(new Uri("http://google.com"));
    Log.Logger.Information("{result}", new
    {
        url = crawledPage.Uri,
        status = Convert.ToInt32(crawledPage.HttpResponseMessage.StatusCode)
    });
