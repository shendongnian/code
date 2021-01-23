    public ActionResult Foo()
    {
        var model = new MyViewModel
        {
            LeftColumnTales = tales.Where((x, i) => i % 3 == 0),
            CenterColumnTales = tales.Where((x, i) => i % 3 == 1),
            RightColumnTales = tales.Where((x, i) => i % 3 == 2),
        };
        return View(model);
    }
