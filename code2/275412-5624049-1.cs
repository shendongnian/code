    public ActionResult Foo() 
    {
        // it's here that you should do the LINQ queries, etc ...
        // not in the view. Views are not supposed to fetch any data
        // and to be intelligent. Views should be dumb and only render
        // the preformatted data that they have been fed by the controller action
        IEnumerable<SomeModel> model = ...
     
        IEnumerable<MyViewModel> viewModel = Mapper.Map<IEnumerable<SomeModel>, IEnumerable<MyViewModel>>(model);
        return View(viewModel);
    }
