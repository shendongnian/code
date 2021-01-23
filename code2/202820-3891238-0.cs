    [HttpPost]
    public virtual ActionResult Edit(IdType id, FormCollection form)
    {
         var newId = //some enum? transform
         var boundModel = UpdateModel(new SomeViewModel(), form);
         return Edit( newId, boundModel );
    }
    [HttpPost]
    public ActionResult Edit(int id, SomeViewModel viewModel)
