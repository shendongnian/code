    var csvCollection = csv.Split(new []{Environment.NewLine},StringSplitOptions.RemoveEmptyEntries)
                                        .Skip(1)
                                        .Select(line => line.Split(',').Select(c=>c.Trim()).ToList());
									
	var movieCollection = csvCollection.Select(x=> new Movie
                                               { 
                                                   FilmMaker = x[0], 
                                                   MovieTitle = x[1], 
                                                   EndDate = DateTime.ParseExact(x[2],"yyyyMMdd",CultureInfo.InvariantCulture)
                                               });
	var result = movieCollection.Where(x=> x.EndDate> new DateTime(2019,12,10))
									.OrderBy(x=>x.EndDate)
									.GroupBy(x=>x.FilmMaker)
									.Select(x=> x.Skip(1).First())
									.ToDictionary(key=>key.MovieTitle,value=>new []{$"FilmMaker:{value.FilmMaker}",$"EndDate:{value.EndDate.Year}{value.EndDate.Month}{value.EndDate.Day}"});
