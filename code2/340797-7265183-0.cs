    [HttpPost]
    public ActionResult Edit(Employer employer, FormCollection col)
    {
        if (ModelState.IsValid)
        {
            var emp = employer;
            //populate emp.Address and emp.PostalAddress with values from col
            entities.Employers.Attach(emp);
            entities.ObjectStateManager.ChangeObjectState(employer, EntityState.Modified);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(employer);
    }
