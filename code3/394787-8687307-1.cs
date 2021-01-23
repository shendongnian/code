    [HttpPost]
    public ActionResult Foo(IDictionary<string, object> model)
    {
        return Json(model);
    }
