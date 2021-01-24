    [HttpPost]
    public IActionResult AddMovie()
    {
        Movie movie = new Movie(id, name, author);
        movieList.Add(movie);
        return RedirectToAction("Index");
    }
