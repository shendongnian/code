    public ActionResult Index(string number)
    { 
        var model = new SearchModel
        {
            Number = number,
            SearchResults = GetByNumber(number)
        };
        return View(model);
    }
    public ActionResult IndexOther(int type, int name)
    {
        var model = new SearchModel
        {
            Type = type,
            Name = name,
            SearchResults = GetByTypeAndName(type, name)
        };
        return View(model);
    }
