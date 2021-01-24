    [HttpPost]
    public ActionResult Report(string name)
    {
     
       //Do server validations here
   
       //set posted value in view bag
        ViewBag.PersonalName = name;
        return View("Index");
     }
