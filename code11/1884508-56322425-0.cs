 c-sharp
public ActionResult Details(int Id = 1)
{
	MoviesData movie = db.MoviesData.Find(Id);
	MovieViewModel MovieVM = new MovieViewModel{
		MovieID = movie.MovieID,
		MovieName = movie.MovieName,
		MovieDescription = movie.MovieDescription,
		MovieCategory = movie.MovieCategory,
		MovieYear = movie.MovieYear
	};
	
	return View(MovieVM);
}
