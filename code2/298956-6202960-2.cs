    [HttpPost]
    public ActionResult Index(Person person)
    {
        if (ModelState.IsValid) //Also not enter the race parameter
        {
            personRepo.Add(person);
            personRepo.Save();
        }
        return RedirectToAction("Index");
    }
