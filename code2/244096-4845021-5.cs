    [AutoMap(typeof(IEnumerable<Users>), typeof(IEnumerable<UserViewModel>))]
    public ActionResult Foo()
    {
        IEnumerable<Users> users = _repository.GetUsers();
        return View(users);
    }
