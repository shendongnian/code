    [HttpPost]
    public ActionResult CreateUser(UserModel model) 
    {
        userService.Create(model);
        return...
    }
    [HttpPut]
    public ActionResult EditUser(UserModel model)
    {
        userService.Update(model);
        return...
    }
