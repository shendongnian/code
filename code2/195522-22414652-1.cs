    protected override ViewResult View(string viewName, string masterName, object model)
    {
        //Whichever condition you like can go here
        if (Request.QueryString["partial"] != null)
            return PartialViewConverter.Convert(PartialView(viewName, model));
        else
            return base.View(viewName, masterName, model);
    }
