    [Authorize(Roles = "Supervisor, Admin")]
    [HttpGet("{username}")]
    public ActionResult UserDetails(string username)
    {
        var model = db.Members.Find(username);
        if (model == null)
        {
            return RedirectToAction("ManageUsers");
        }
        return View(model);
    }
