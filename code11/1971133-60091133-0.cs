    [AllowAnonymous]
    public ActionResult NavRoleItems()
    {
        ViewBag.Projects = db.Projects;
        return View();
     }
