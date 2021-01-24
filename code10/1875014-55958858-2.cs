    // Assume your PersonellData looks like below.    
    class PersonellData
    {
        int Id { get; set; }
        string Name { get; set; }
    }
    public IEnumerable<SelectListItem> GetAllPersonnelCached()
    {
        CacheHelper.SaveToCache("mykey", valueToCache, 240);
        var cachedPersonnelData = CacheHelper.GetFromCache<IEnumerable<PersonnelData>>("mykey");
        return cachedPersonnelData.Select(o => new SelectListItem(o.Name, o.Id.ToString());
    }
