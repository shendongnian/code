    public void LoadPrices()
    {
        // Prices loading...
        Prices = prices;
        foreach (var price in Prices)
        {
            price.PropertyChanged += (s, e) => 
            {
                if (e.PropertyName.Equals(nameof(Price.GivenPrice)))
                {
                    // do your WCF call here...
                }
            };
        }
    }
