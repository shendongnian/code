     [HttpGet("{start}/{end}")]
     public IEnumerable<Movie> GetReport([FromUri]int start, [FromUri]int end)
     {
         return _context.Movies
             .Where(m => (m.Rating >= start) && (m.Rating <= end))
             .OrderBy(x => x.YearRelease)
             .ToList();
     } 
