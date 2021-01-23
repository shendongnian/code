    [HttpPost]
    [ActionName("Index")]
    public ActionResult HandleATroll(TrollModel trollModel)
    {
        return View(trollModel);
    }
