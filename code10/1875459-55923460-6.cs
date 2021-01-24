    public ActionResult SomeMethodThatReturnsPartialView(int id)
    {
        var model = GetProducts();
        return PartialView("_IndexPartial", model);
    }
