    var genreModel = storeDB.Genres.Where(g => g.Name == genre)
                                           .Select(g => new GenreAlbumView
                                           {
                                               ID = g.GenreId,
                                               Name = g.Name,
                                               Albums = g.Albums.Skip(PageSize * (PageIndex -1).Take(PageSize)
                                           }).SingleOrDefault();
