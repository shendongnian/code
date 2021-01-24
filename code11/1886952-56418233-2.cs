    // use group join to get movies with duration > 60 min
	var filteredMovies = 
		from d in directors
		join m in movies.Where(x => x.DurationMinutes >= 60 && x.ReleaseDate <= new DateTime(2015, 12, 31) && x.Rating >= 9)
		on  d.Id equals m.DirectorId into groupMovies
		let moviesCountForEachDirector = groupMovies.Count()
		where moviesCountForEachDirector > 1
		select groupMovies;
	
	// use group join to get movies with actors from 3 to 7
	var moviesWithActors = 
		from m in filteredMovies.SelectMany(x => x)
		join ma in movieActor on m.MovieId equals ma.MovieId into groupJoin
		let actorsInEachMovieCount = groupJoin.Count()
		where actorsInEachMovieCount > 2 && actorsInEachMovieCount < 8
		select new 
		{
			MovieId = m.MovieId,
		};
	
	// the rest of query
	var query = 
		from d in directors
		join m in movies on d.Id equals m.DirectorId
		join ma in moviesWithActors on m.MovieId equals ma.MovieId
		group d by d.Id into gr	
		select new { DirectorName = gr.First().Name };
