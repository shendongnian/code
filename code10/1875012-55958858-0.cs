    public IEnumerable<SelectListItem> GetAllPersonnelCached()
    {
        CacheHelper.SaveToCache("mykey", valueToCache, 240); //HttpContext.Current.Cache.Add
        var cachedItems = CacheHelper.GetFromCache<IEnumerable<SelectListItem>>("mykey");
        return cachedItems.Select(o => new SelectListItem(o.Text, o.Value);
    }  
