    public async Task<IActionResult> App(decimal budget)
        {
            var movie = await _context.Movies.Where(m => m.Price <= 
            budget).ToListAsync();
            if (movie == null)
            {
                return NotFound();
            }
            return PartialView(movie);
        }
