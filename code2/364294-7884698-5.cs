    public ActionResult Create(ScheduleCreate mod)
        {
            if (ModelState.IsValid)
            {
                Schedule newschedule = db.Schedule.Add(mod.schedule);
                if (mod.schedTime != null)
                {
                    foreach (string instanceTime in mod.schedTimes)
                    {
                   newschedule.Times.Add(DateTime.Parse(instanceTime) });//Something wrong here
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");  
            }
            PopulateDropDown();
            return View(mod.schedule);
    }
        
