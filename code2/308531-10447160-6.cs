    [HttpPost]
    public ActionResult Index(A model)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("NextAction");
        }
        return View();
    }
