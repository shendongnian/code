    [HttpPut]
    public ActionResult Create(MyObjectViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            // there are validation errors => redisplay the view
            return View(viewModel);
        }
        var model = Mapper.Map<MyObjectViewModel, MyObject>(viewModel);
        _repository.DoSomethingWithTheModel(model);
        return RedirectToAction("Success")
    }
