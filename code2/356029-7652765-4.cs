    public ActionResult Foo()
    {
        var model = db
            .Languages
            .Select(x => new LanguageViewModel
            { 
                Name = x.Name, 
                EnglishName = x.EnglishName, 
                Id = x.Id 
            })
            .ToList();
        return View(model);
    }
