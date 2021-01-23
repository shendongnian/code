    [HttpPost]
    public ActionResult Create(MyThing newThing)
    {
        if (ModelState.IsValid)
        {
            try
            {
                DB.MyThing.AddObject(newThing);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error creating new Thing");
            }
        }
        return View(newThing);
    } 
