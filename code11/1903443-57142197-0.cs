    [HttpPost]
    public ActionResult Random(string movieid, string moviename)
    {
       var movie = new Movie();
       movie.id = movieid;
       movie.name = moviename;
       return View(movie);
    }
