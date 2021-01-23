    public ActionResult Foo()
    {
        SomeModel model = _repository.GetModel();
        SomeViewModel viewModel = Mapper.Map<SomeModel, SomeViewModel>(model);
        return View(viewModel);
    }
