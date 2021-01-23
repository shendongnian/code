    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Register(AdRegister adRegister, IEnumerable<HttpPostedFileBase> files)
    {
        ...
        string id = Repository.Save(adRegister);
        return RedirectToAction("Validate", new { id = adRegister.Id });
    }
