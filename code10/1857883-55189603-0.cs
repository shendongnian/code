    [HttpPost]
    public ActionResult Create([Bind(Include = "PersonId" + "," + "ActivityTypeId")] dbo_Activities dbo_Activities)
    {
        if (ModelState.IsValid) {
            db.dbo_Activities.Add(dbo_Activities);
            db.SaveChanges();
            //set LatestActivityId on the person to the ActivityId of the entry that was just created
            var person = db.dbo_Persons.Single(x => x.Id == dbo_Activities.PersonId);
            person.LatestActivityId = dbo_Activities.ActivityId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewData["PersonId"] = new SelectList(db.dbo_Businesses, "PersonId", "FullName", dbo_Activities.PersonId);
        return View(dbo_Activities);
    }
