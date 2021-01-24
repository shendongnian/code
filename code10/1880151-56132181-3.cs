    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Id,MarkaId")] Model model)
    {
        if (ModelState.IsValid)
        {
            db.Models.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.MarkaId = new SelectList(db.Markas, "Id", "Name", model.MarkaId);
        return View(model);
    }
