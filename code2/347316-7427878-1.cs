    [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
    public ActionResult Foo() 
    {
        var model = SomeExpensiveOperationToFetchData();
        return View(model);
    }
