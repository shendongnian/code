    public ActionResult PostMessage(string msg, string imgName)  
    {
        if (SomeErrorWhileSavingInDb)
        {
            // something wrong happened => we could add a modelstate error
            // explaining the reason and return the Index view.
            ModelState.AddModelError("key", "something very wrong happened when trying to process your request");
            return View("Index");
        }
        // everything went fine => we can redirect
        return RedirectToAction("Success");
    }
