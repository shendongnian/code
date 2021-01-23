    [HttpGet]
    public ViewResult Edit(int id)
    {
        //build and populate view model
        var viewModel = new EditViewModel();
        viewModel.Id = id;
        viewModel.Name = //go off to populate fields
        return View("", viewModel)
    }
    [HttpPost]
    public ActionResult Edit(EditViewModel viewModel)
    {
        //use data from viewModel and save in database
    }
