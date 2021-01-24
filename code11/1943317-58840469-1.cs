    private Product GetProductFromCache(string cacheKey)
    {
        IMemoryCache _memoryCache;
        Product product;
        if (!_memoryCache.TryGetValue(cacheKey, out product))
        {
            product = GetProductsFromRepository()
                        .Select(o => new SelectListItem(o.Name, o.Id.ToString()));
        }
        return product;
    }
