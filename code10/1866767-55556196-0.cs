    public ActionResult Siblings(int? id)
    {
        AvailableAnimals availableAnimals = db.AvailableAnimals.Find(id);
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        else if (id != null)
        {
            List<AvailableAnimals> siblings = db.AvailableAnimals.Where(x => x.ACSireID == id || x.ACDamID == id).ToList();
            return View(siblings);
        }
        if (availableAnimals == null)
        {
            return HttpNotFound();
        }
        return View(availableAnimals);
    }
