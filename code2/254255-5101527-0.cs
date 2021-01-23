    public ActionResult Foo()
    {
        MyViewModel model = ...
        return new ExcelResult<MyViewModel>(
            ControllerContext,
            "~/Views/Home",
            "Foo.ascx",
            model
        );
    }
