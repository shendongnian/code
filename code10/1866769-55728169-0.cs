        AvailableAnimals availableAnimals = db.AvailableAnimals.Find(id);
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        else if (id != null)
        {
            var siblings = db.AvailableAnimals.Where(x => x.ACSireID == availableAnimals.ACSireID || x.ACDamID == availableAnimals.ACDamID).Include(x => x.FemaleBreederAnimals).Include(x => x.MaleBreederAnimals);
            return View(siblings);
        }
        if (availableAnimals == null)
        {
            return HttpNotFound();
        }
        return View(availableAnimals);
    }
