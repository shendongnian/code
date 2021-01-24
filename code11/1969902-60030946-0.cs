    private List<SelectListItem> getGenres () {
        var Genres = new List<SelectListItem>();
        var dbGenres = _appDbContext.Genres.ToList();
    
        var SelectListGroups = dbGenres.Where(x => x.ParentId == 0)
            .ToDictionary(y => y.Id,y=> new SelectListGroup(){ Name = y.Name });
    
        foreach (var genre in dbGenres) {
            if (genre.ParentId != 0) {
                Genres.Add(new SelectListItem() {
                    Value = genre.Id.ToString(),
                    Text = genre.Name,
                    Group = SelectListGroups[genre.ParentId]
                });
            }
        }
        return Genres;
    }
