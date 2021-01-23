    public PartialViewResult MySearchControl()
    {
        //initialize the model
        return new PartialView(model)
    }
    [HttpPost]
    public PartialViewResult MySearchControl(MyModel model)
    {
        //do work, repopulate the model
        return new PartialView(model)
    }
