    [HttpPost]
    public ActionResult Index(A modelA, B modelB)
    {
        modelA.ModelB = modelB;
        if (ModelState.IsValid)
        {
            return RedirectToAction("NextAction");
        }
        return View();
    }
