    public ActionResult Details(int id)
    {
        var model = _repository.Retrieve(id);
        return ViewForModel("Details", model);
    }
    public ActionResult Edit(int id)
    {
        var model = _repository.Retrieve(id);
        return ViewForModel("Edit", model);
    }
    private ActionResult ViewForModel(string viewName, object model)
    {
        return model == null
            ? View("NotFound")
            : View(viewName);
    }
