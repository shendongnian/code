    public List<items> GetDropdownlistItems()
    {
        string cacheKey = "dropdownlistItems";
    
        if (HttpContext.Current.Cache[cacheKey] != null)
        {
            return (List<items>)HttpContext.Current.Cache[cacheKey];
        }
    
        var items = GetItemsFromDatabase();
    
        HttpContext.Current.Cache.Insert(cacheKey, items, null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
    
        return items;
    }
