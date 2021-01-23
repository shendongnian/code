    [HttpPost]
    public ActionResult MyAction(MyModel model) {
        if (ModelState.IsValid) {
             // save to db, for instance
             return RedirectToAction("AnotherAction");
        }
        // model is not valid
        return View("MyView", model);
    }
