    public ActionResult Index()
    {
        var conID = 1; //BASED ON DATA-INPUT
        var userExists = DB.Users.Where(x => x.UserID = conID).FirstOrDefault();
        return View(userExists?.Name);
    }
