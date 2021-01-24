     public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var album = await _context.Albums
            .Include(a => a.Music).Where(a => a.AlbumID == id)
            .Select(a => new ArtistViewModel()
            {
                Artist = a.Artist,
                Title = a.Music.Select(m=>m.Title).ToList()
            }).FirstOrDefaultAsync();
            if (album == null)
            {
                return NotFound();
            }
            return new JsonResult(album);
        }
