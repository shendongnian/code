    public ActionResult Create(ScheduleCreate mod)
        {
            if (ModelState.IsValid)
            {
                Schedule newschedule = db.Schedule.Add(mod.schedule);
                if (mod.schedTime != null)
                {
                    foreach (string instanceTime in mod.schedTimes)
                    {
                   newschedule.Times.Add(new {Time = DateTime.Parse(instanceTime) }); // unteseted
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");  
            }
            PopulateDropDown();
            return View(mod.schedule);
    }
        
