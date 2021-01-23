    [HttpPost]
    public ActionResult Foo(SomeViewModel model)
    {
        // model.Data.Filters will be properly bound here
        ...
    }
