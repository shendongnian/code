    public ActionResult Show(int userId)
    {
        var user = _repository.Load<User>(userId);
        var model = new ShowUserModel(user);
        return View(model);
    }
