    public ActionResult Create(FormCollection collection) {
        ///do your checks here which you cant do using attributes
        ModelState.AddModelError("fieldname", "yourErrorMessage");
    
        if (ModelState.IsValid) {
            ////.........
        }
        return View();
    }
