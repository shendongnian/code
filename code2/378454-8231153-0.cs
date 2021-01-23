        IList<Price> selectedPrices = ...;
        IEnumerable<Price> additionalPrices = ...;
        IDictionary<int, Price> pricesById = new Dictionary<int, Price>();
        foreach (var price in selectedPrices) 
        { 
            pricesById.Add(price.Id, price); 
        }
        foreach (var price in additionalPrices)
        {
            if (!pricesById.ContainsKey(price.Id))
            {
                selectedPrices.Add(price);
            }
        }
