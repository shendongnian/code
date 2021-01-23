    public enum TemplateType
    {
       SingleColumn,
       TwoColumn
    }
    [HttpGet]
    public ActionResult Edit(TemplateType templateType)
    {
        var row = new ContentPage();
        TemplateBase template; 
        if (templateType == TemplateType.SingleColumn)
        {
            template = new SingleColumnTemplate();
        }
        else
        {
            template = new TwoColumnTemplate();
        }
        ...
        return View(row);
    }
