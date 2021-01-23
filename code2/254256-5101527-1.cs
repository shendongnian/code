    public ActionResult Foo()
    {
        SomeViewModel model = ...
        return new ExcelResult<SomeViewModel>
        (
            ControllerContext,
            "~/Views/Home/Foo.ascx",
            "Foo.xlsx",
            model
        );
    }
