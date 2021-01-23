    public IProductPriceFetcher GetWebServiceFetcher()
    {
        return new DatabaseCachingFetcherDecorator(new WebServiceFetcher());
    }
    public IProductPriceFetcher GetWebsiteFetcher()
    {
        return new DatabaseCachingFetcherDecorator(new WebsiteFetcher());
    }
