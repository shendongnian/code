     public ActionResult Index()
        {
            PAPEntities db = new PAPEntities();
            MoviesData movie = db.MoviesData.SingleOrDefault(x => x.MovieID == 1);
            List<MovieViewModels> MovieVM = new List<MovieViewModels>
                {
                    new MovieViewModels {
                     MovieID = movie.MovieID,
                     MovieName = movie.MovieName,
                     MovieDescription = movie.MovieDescription,
                     MoviePrice = movie.MoviePrice,
                     MovieCategory = movie.MovieCategory,
                     MovieYear = movie.MovieYear
                        },
            };
            return View(MovieVM);
        }
    }
