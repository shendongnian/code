    [Authorize]
    public ActionResult Poll()
    {
        bool isUpdated = CheckForUpdates(User.Identity.Name);
        return Json(isUpdated, JsonRequestBehavior.AllowGet);
    }
