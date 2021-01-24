`cs
public interface IHasId<TKey> 
    where TKey : IEquatable<TKey>
{
    TKey Id { get; set; }
}
`
Another thing to consider is ordering the entities, when querying for a list of entities we need to sort them to get the right paged entities. So, we can create another interface to specify the sorting property e.g. Name.
`cs
public interface IOrdered
{
    string Name { get; set; }
}
`
Our objects must implement the common interfaces like below:
`cs
public class Player : IHasId<string>, IOrdered
{
    public string Id { get; set; }
    public string Name { get; set; }
    ...
}
public class Treasure : IHasId<int>, IOrdered
{
    public int Id { get; set; }
    public string Name { get; set; }
    ...
}
`
Now create a generic base api controller, make sure to mark the methods as virtual so we can override them in the inherited api controllers if necessary.
`cs
[Route("api/[controller]")]
[ApiController]
public class GenericBaseController<T, TKey> : ControllerBase
    where T : class, IHasId<TKey>, IOrdered
    where TKey : IEquatable<TKey>
{
    private readonly ApplicationDbContext _context;
    public GenericBaseController(ApplicationDbContext context)
    {
        _context = context;
    }
    // make methods as virtual, 
    // so they can be overridden in inherited api controllers
    [HttpGet("{id}")]
    public virtual T Get(TKey id)
    {
        return _context.Set<T>().Find(id);
    }
    [HttpPost]
    public virtual bool Post([FromBody] T value)
    {
        _context.Set<T>().Add(value);
        return _context.SaveChanges() > 0;
    }
    [HttpPut("{id}")]
    public virtual bool Put(TKey id)
    {
        var entity = _context.Set<T>().AsNoTracking().SingleOrDefault(x => x.Id.Equals(id));
        if (entity != null)
        {
            _context.Entry<T>(value).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
        return false;
    }
    [HttpDelete("{id}")]
    public virtual bool Delete(TKey id)
    {
        var entity = _context.Set<T>().Find(id);
        if (entity != null)
        {
            _context.Entry<T>(entity).State = EntityState.Deleted;
            return _context.SaveChanges() > 0;
        }
        return false;
    }
    [HttpGet("list/{pageNo}-{pageSize}")]
    public virtual (IEnumerable<T>, int) Get(int pageNo, int pageSize)
    {
        var query = _context.Set<T>();
        var totalRecords = query.Count();
        var items = query.OrderBy(x => x.Name)
            .Skip((pageNo - 1) * pageSize)
            .Take(pageSize)
            .AsEnumerable();
        return (items, totalRecords);
    }
}
` 
The rest is easy, just create api controllers that inherits from the base generic controller:
PlayersController :
`cs
[Route("api/[controller]")]
[ApiController]
public class PlayersController : GenericBaseController<Player, string>
{
    public PlayersController(ApplicationDbContext context) : base(context)
    {
    }
}
`
TreasuresController :
`cs
[Route("api/[controller]")]
[ApiController]
public class TreasuresController : GenericBaseController<Treasure, int>
{
    public TreasuresController(ApplicationDbContext context) : base(context)
    {
    }
}
`
you don't have to create any methods, but you are still able to override the base methods since we marked them as virtual e.g.:
`cs
[Route("api/[controller]")]
[ApiController]
public class TreasuresController : GenericBaseController<Treasure, int>
{
    public TreasuresController(ApplicationDbContext context) : base(context)
    {
        public ovedrride Treasure Get(int id)
        {
            // custom logic ….
            return base.Get(id);
        }
    }
}
`
You can download a sample project from GitHub: https://github.com/LazZiya/GenericApiSample
