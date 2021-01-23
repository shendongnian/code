    class DatabaseCachingFetcherDecorator : IProductPriceFetcher
    {
        private readonly IProductPriceFetcher innerFetcher;
        public DatabaseCachingFetcherDecorator(IProductPriceFetcher fetcher)
        {
            this.innerFetcher = fetcher;
        }
        public double GetPrice(int id)
        {
            double price = this.innerFetcher.GetPrice(id);
            if (price != 0) // or some other value representing "price not found"
            {
                SavePriceToDatabase(id, price);
            }
            return price;
        }
        private SavePriceToDatabase(int id, double price)
        {
            // TODO: Implement...
        }
    }
