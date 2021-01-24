    public ActionResult Profil()
    {
        var user = dbContext.Members.Where(m=>m.loginid == Session["loginid"]).FirstOrDefault();
        return View(user);
    }
