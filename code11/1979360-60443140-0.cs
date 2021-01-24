csharp
<li>Actors: @string.Join("," Model.Movie.Actors.Select(a => a.Name).ToList())</li>
In this way, you will show a list of actors' names associated with the movie you added to your view model.
But I would suggest you refactor your view model to include a List<string> of actors' names, so you would remove the logic from your view. After that, your view should look like: 
csharp
public class MovieDetailsViewModel
{
    public Movie Movie { get; set; }
    public List<string> ActorsNames { get; set; }
}
In your controller you should do:
csharp
public ActionResult Details(int id)
{
	var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
	var viewModel = new MovieDetailsViewModel
	{
		Movie = movie,
		ActorsNames = string.Join(",", movie.Actors.Select(a => a.Name).ToList())
	};
	if (movie == null)
		return HttpNotFound();
	return View(viewModel);
}
As you can see, I have removed the code where you get a single actor from the Actors DbSet because it isn't useful. Indeed, you want the full list of all actors that have appeared in the movie you get from the Movies DbSet, not just an actor that has the same id of the movie of which you have to load the details.
Also, be sure to have activated lazy loading to get the collection of actors associated with the movie, otherwise, you will get an empty collection.
Let me know if my suggestions will be useful.
