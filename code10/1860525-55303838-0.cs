    [ValidateAntiforgeryToken]
    [HttpPost]
    public ActionResult View1(View1ViewModel model)
    {
        if (ModelState.Isvalid)//check if valid
        {
            var newModel = new View2ViewModel()
            {
                Email = model.Email,
                LastName = model.LastName,
                FirstName = model.FirstName
            };
            return View("~/The path of view 2", newModel);//go to view 2
        }
        return View(model);//return the first view if it's not valid
    }
