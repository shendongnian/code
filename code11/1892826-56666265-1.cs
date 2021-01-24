    [HttpPost]
    public ActionResult Display(SomeClass someClass)
    {
        if (ModelState.IsValid)
        {
             ...
             return RedirectToAction("Index");
        }
        return view;
    }
