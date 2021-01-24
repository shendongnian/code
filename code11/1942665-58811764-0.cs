    public ActionResult Profil(int id) //As you pass the parameter, suppose PK is int
    {
        var user = dbContext.Users.GetById(id);
        return View(user);
    }
