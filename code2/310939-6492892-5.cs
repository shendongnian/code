    public ActionResult Foo()
    {
        SomeViewModel model = ...
        return this.Xml(model);
    }
