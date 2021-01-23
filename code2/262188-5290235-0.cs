    public void UpdateBandGenres(Guid bandId, IEnumerable<Guid> newGenreIds)
    {
        using (var ctx = new OpenGroovesEntities())
        {
            List<Genre> newGenres = ctx.
                                    Genres.
                                    Where(g => newGenreIds.Contains(g.GenreId)).
                                    ToList();
            Band band = ctx.Bands.Single(b => b.BandId == bandId);
            band.Genres.Clear();
            newGenres.ForEach(band.Genres.Add);
            ctx.SaveChanges();
        }
    }
