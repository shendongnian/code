    [Authorize]
    public ActionResult Poll()
    {
        bool isUpdates = CheckForUpdates(User.Identity.Name);
        return Json(isUpdates, JsonRequestBehavior.AllowGet);
    }
