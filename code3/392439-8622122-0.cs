    List<AdSlot> list;
    using(var dbc = new DbDataContext())
    {
        var loadOptions = new DataLoadOptions();
        loadOptions.LoadWith<AdSlot>(n => n.AdSize);
        dbc.LoadOptions = loadOptions;
        
        list = dbc.AdSlots.Where(a => a.PublisherId == publisherId).ToList();
    }
    ViewData["AdSlots"] = list;
