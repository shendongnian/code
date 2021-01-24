    public ActionResult updatePerson()
    {
        Service1Client SEObj = new Service1Client();
        List<Person>PeLi =SEObj.GetPersons().ToList();
        ViewBag.List = PeLi.Select(x => new SelectListItems {
            Value = x.Id,
            Text = x.FName + " " + x.LName
        });
        return View();
    }
