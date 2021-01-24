     public ActionResult Movies() {
      var genres = _context.Genres
       .Select(g => new CountOfVideos {
        Classification = g.Name, NumberOfMovies = g.Videos.Count()
       })
       .OrderBy(c => c.NumberOfMovies)
       .ToList();
    
      return View(genres);
     }
