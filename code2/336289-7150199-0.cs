    [HttpPost]
    public ActionResult Index(MyModel model) {
        model.Foo += "bar";
        ModelState.Clear();
        return View(model);
    }
