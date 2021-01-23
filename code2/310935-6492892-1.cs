    public ActionResult Foo()
    {
        SomeViewModel model = ...
        return new XmlResult(model);
    }
