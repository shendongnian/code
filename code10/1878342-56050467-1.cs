c#
public class Album
{
    public int AlbumId { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
}
public class Genre
{
    public int GenreId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Album> Albums { get; set; }
}
But obviously you don't want/need to reveal everything you have in your persistence storage to the user. Hence you create view models and **only** contain what you want to display.
### View Models ###
Let's say you have a view to display information about the selected album. You might create a view model like this:
c#
public class AlbumViewModel
{
    public int AlbumId { get; set; }
    public string AlbumName { get; set; }
    public string Genre { get; set; }
}
Then in the album controller, you can build the view model by using any ORM, lazy loading, etc:
### Controller ###
If you happen to use `EntityFramework` and have lazy loading enable, you can fetch genre name via its navigation property:
c#
public ActionResult Details(int id)
{
    var album = _dbContext.Albums.SingleOrDefault(x => x.AlbumId == id);
    if (album == null)
    {
        return HttpNotFound();
    }
    var vm = new AlbumViewModel
    {
        AlbumId = album.AlbumId,
        AlbumName = album.Title,
        // You can get the genre name via Navigation property, and/or lazy
        // loading
        Genre = album.Genre.Name
    };
    return View(vm);
}
Now in a more advanced architecture, the read and write is separated, which is 
 referred as CQRS. For all the reads (i.e., displaying information to the user), you can build your view model with data directly from executing plain SQL statement.
###CQRS with Dapper###
c#
using Dapper;
using System.Data;
...
public class AlbumController : Controller
{
    private readonly IDbConnection _dbConnection;
    public AlbumController(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public ActionResult Details(int id)
    {
        const string sql = @"
SELECT a.AlbumId, a.Title AS [AlbumName], g.Name AS [Genre]
FROM [Album] a
    JOIN [Genre] g ON a.GenreId = g.GenreId
WHERE a.AlbumId = @albumId;
";
    
        var vm = _dbConnection.QuerySingleOrDefault<AlbumViewModel>(sql, new {
            albumId = id
        });
    
        return View(vm);
    }
}
