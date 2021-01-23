    [HttpPost]
    public virtual ActionResult SaveData(int movieId, FormCollection form)
    {
        // Get movie to update
        Movie movie = db.Movies.Where(x => x.Id == movieId);
        // Update movie object with values from form collection.
        TryUpdateModel(movie, form);
        // Do model validation
        if (!ModelState.IsValid)
            return View();
        return View("success");
    }
