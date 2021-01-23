    class ProductPriceInfo 
    {
        public string ID {get;set;}
        public DateTime PriceTimeStamp {get;set;}
        public decimal Price {get;set;}
    }
    ...
    Dictionary<string, ProductPriceInfo> _prices = new Dictionary<string, ProductPriceInfo>();
    // Adding a price
    _prices.Add(myProduct.ID, myProduct);
    // updating the price
    if(_prices[myProductv2.ID].PriceTimeStamp < myProductv2.PriceTimeStamp)
    {
        _prices[myProductv2.ID].PriceTimeStamp = myProductv2.PriceTimeStamp;
        _prices[myProductv2.ID].Price = myProductv2.Price;
    }
