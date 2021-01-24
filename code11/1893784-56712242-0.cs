    [HttpGet]
    [ActionName("Registration")]
    public ActionResult Registration_Get()
    {
        //Contry();
        return View();
    } 
    [HttpPost]
    [ActionName("Registration")]
    public ActionResult Registration_Post(Registration r)
    {
        //This needs to come from the view
        //Registration register = new Registration();
        //TryUpdateModel(r);
 
        if (ModelState.IsValid)
        {
            AddStudent(r);
            return RedirectToAction("Registration");
        }
 
        return View(r);
    }
    You are not yet passing the model from the view
