    MovieViewModel viewModel = new MovieViewModel()
    {
       MovieID = moviesData.MovieID (or maybe only .ID?),
       MovieName = moviesData.MovieName
    
       etc....
     
    }
    
    return View(viewModel );
