    public ActionResult Edit(Movie model) //renamed from movieToEdit
    {
    	if (ModelState.IsValid)
    	{
    		var movie= _db.Movies.Where(m => m.Id == model.Id).SingleOrDefault();			 
    		movie.x = model.x;
    		movie.y = model.y;
    		_db.SaveChanges();
    		return RedirectToAction("Index");
    	}
    	return View(model);			
    }
