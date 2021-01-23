    public ActionResult Edit(int id)
    {
        var model = new AlbumViewModel
        {
            Genres = storeDB.Genres.OrderBy(g => g.Name),
            Artists = storeDB.Artists.OrderBy(a => a.Name),
            Album = storeDB.Albums.Single(a => a.AlbumId == id)
        };
        return View(model);
    }
