    [HttpPost]
    public ActionResult Edit(int id, DateTime start, DateTime end)
    {
        //get the right model to edit
        var sprintToEdit = Db.GetById(id);
        //copy the changed fields
        sprintToEdit.Start = start;
        sprintToEdit.End = end;
        if (ModelState.IsValid)
        {
            Db.Save(sprintToEdit);
            return RedirectToAction("Index");
        }
        else
            return View(sprintToEdit);
    }
