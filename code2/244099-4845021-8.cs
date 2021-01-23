    public ActionResult Foo()
    {
        IEnumerable<Users> users = _repository.GetUsers();
        IEnumerable<UserViewModel> usersViewModel = Mapper
            .Map<IEnumerable<Users>, IEnumerable<UserViewModel>>(users);
        return View(usersViewModel);
    }
