    [HttpPost]
    public ActionResult CreateToy(ToyViewModel _viewModel)
    {
        var model = new Toy();
        model.Name = _viewModel.Name
        // etc.
        _service.CreateToy(model);
        // return whatever you like.
        return View();
    }
