    NetflixCatalog cat = new NetflixCatalog(CatalogUri);
    string searchString = "Michael Caine";
    var person = (from r in cat.People where r.Name == searchString select r).Single();
    var query  = (from p in cat.People 
                  where p.Id == person.Id 	
                  from t in p.TitlesActedIn
                  orderby t.ReleaseYear
                  select new Title
                          {
                              Name = t.Name,
                              BoxArt = t.BoxArt,
                              Synopsis = t.Synopsis,
                              ReleaseYear = t.ReleaseYear,
                              Runtime = t.Runtime,
                              Type = t.Type,
                              Genres = t.Genres,
                              Cast = t.Cast
                          };
