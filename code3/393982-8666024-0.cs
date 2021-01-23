    public ActionResult DoSomething(MyModel model)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("somethign");
        }
        return View(model);
    }
