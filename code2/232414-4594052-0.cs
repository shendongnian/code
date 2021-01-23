    [HttpGet]
    public ActionResult Edit(TemplateType templateType)
    {
        var row = new ContentPage();
        TemplateBase template = (TemplateBase)Activator.CreateInstance(templateType);
    
        ...
    
        return View(row);
    }
