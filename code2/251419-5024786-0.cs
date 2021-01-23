    [HttpPost]
    public ActionResult Edit(Movie movie)
    {
        if (movie == null)
        {
            TempData["MESSAGE"] = "No movie with id = " + id + ".";
            return RedirectToAction("Index", "Home");
        }
        if (!ModelState.IsValid)
            return View(movie);
        // what method do I have to invoke here
        // to update the movie object based on the model parameter?
        db.Movie.AddObject(movie);
        db.ObjectStateManager.ChangeObjectState(movie, System.Data.EntityState.Modified);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
