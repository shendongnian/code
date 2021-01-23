    [NonAction]
    public override ActionResult Edit(IdType id, FormCollection form)
    {
       // do nothing or throw exception
    }
    
    [HttpPost]
    public ActionResult Edit(int id, SomeViewModel viewModel)
    {
       // your implementation
    }
