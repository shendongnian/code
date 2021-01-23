    public ActionResult GetToyForm()
    {
        var viewModel = new ToyViewModel();
        viewModel.Categories = _service.GetListOfCategories();
        return View(viewModel);
    }
