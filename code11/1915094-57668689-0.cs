    public async Task<IActionResult> Index()
    {    
        var movies = await _context.Movies.ToList();
        if (movies == null)
        {
            return NotFound();
        }
        return View(movies);
    }
