       public ActionResult Details(int Id = 1)
        {
            MoviesData movie = db.MoviesData.Find(Id);
            MovieViewModel MovieVM = new MovieViewModel();
            MovieVM.MovieID = movie.MovieID;
            MovieVM.MovieName = movie.MovieName;
            MovieVM.MovieDescription = movie.MovieDescription;
            MovieVM.MovieCategory = movie.MovieCategory;
            MovieVM.MovieYear = movie.MovieYear;
    
            return View(MovieVM);
        }
