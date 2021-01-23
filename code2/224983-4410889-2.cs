    [HttpPost]
    public ActionResult Create(ComplexModel model)
    {
        if (ModelState.IsValid)
        {
            var test = model.SomeStringsComplex;
            // Do something to Create the object
            RedirectToAction("Index");
        }
        // Model State is invalid, return so the user can correct
        return View(model);
    }
