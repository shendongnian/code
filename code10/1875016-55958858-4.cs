    // Assume your PersonnelData looks like below.    
    class PersonnelData
    {
        int Id { get; set; }
        string Name { get; set; }
    }
    public IEnumerable<SelectListItem> GetAllPersonnelCached()
    {
        // valueToCache is a list of PersonnelData objects.
        CacheHelper.SaveToCache("mykey", valueToCache, 240);
        var cachedPersonnelData = CacheHelper.GetFromCache<IEnumerable<PersonnelData>>("mykey");
        return cachedPersonnelData.Select(o => new SelectListItem(o.Name, o.Id.ToString());
    }
