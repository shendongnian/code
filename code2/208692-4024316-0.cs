    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Edit(Service service)
    {
        Service originalService = GetService(id);
    
        UpdateModel(originalService, new string[] { "Field1thatyouwanttoupdate", "fieldname2" });
    }
