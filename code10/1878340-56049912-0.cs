        var music = _context.Music.SingleOrDefault(c => c.Id == id);
        var musicGenres = _context.MusicGenres.Where(gi => gi.Id == music.GenreId).ToList(); // whatever the genre id property is called.
        MusicViewModel vmMusic = new MusicViewModel
        {
            Music = music,
            MusicGenres = musicGenre
        };
        return View(vmMusic); 
