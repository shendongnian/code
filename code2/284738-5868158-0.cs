    public ActionResult View(int id) 
    {
        var user = _repository.Get(id);
        var viewModel = AutoMapper.Map<UserViewModel, User>(user);
        return Json(viewModel);
    }
