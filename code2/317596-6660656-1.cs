    Item item = GetSomeItem();
    int price = 0;
    if (price_cache.TryGetValue(item, out price))
    {
        // we got the price
    }
    else
    {
        // there is no such key in the dictionary
    }
