     public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var music = await _context.Music
                .Include(m => m.Album).Where(m => m.MusicID == id)
                .Select(m => new ArtistViewModel()
                {
                    Artist = m.Album.Artist,
                    Title = m.Title
                }).FirstOrDefaultAsync();
            if (music == null)
            {
                return NotFound();
            }
            return View(music);
        }
