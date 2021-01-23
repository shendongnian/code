    public ActionResult MyMethod() {
        var user = _unitOfWork.Get(user)
        var userViewModel = Mapper.Map<User, UserViewModel>(user);
        return View(userViewModel);
    }
