    [HttpPost]
    public ActionResult UploadMovie(MovieVM model)
    {
        if (ModelState.IsValid)
        {
            // save file
            // ...
            // Map to Entity to save to db
            Movie movie = new Movie
            {
                Title = model.Title,
                FileName = model.Image.FileName
            };
            db.Movies.Add(movie);
            db.SaveChanges();
            return RedirectToAction("Success");
        }
        return View(model);
    }
