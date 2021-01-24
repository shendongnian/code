 c#
MovieViewModel[] movies = db.MoviesData.Select(movie => new MovieViewModel
{
    MovieID = movie.MovieID,
    MovieName = movie.MovieName,
    MovieDescription = movie.MovieDescription,
    MoviePrice = movie.MoviePrice,
    MovieCategory = movie.MovieCategory,
    MovieYear = movie.MovieYear
}).ToArray();
return View(movies);
(this also means the SQL might be limited to just the columns that you're interested in, avoiding fetching unnecessary columns)
Then in the view, you should have:
 c#
@model MovieViewModel[]
which tells razor the type to use for `Model`.
With that: things should work.
        
