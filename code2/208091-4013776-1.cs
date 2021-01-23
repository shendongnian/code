    public ActionResult Create(Booking item)
    {
        if (ModelState.IsValid)
        {
            int newID = _tasks.Create(item);
            // NEW section to emulate model being populated for use in Details view
            TempData["additionalData"] = "Person created successfully";
            return RedirectToAction("Details", new { id = newID });
        }
        else
        {
            return View();
        }
    }
