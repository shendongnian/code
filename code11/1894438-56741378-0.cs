csharp
    public class GenericRepository<TEntity, TContext>
        where TContext : DbContext
        where TEntity : class
    {
        protected readonly TContext context;
        public GenericRepository(TContext context)
        {
            this.context = context;
        }
        public virtual async Task Add(TEntity model)
        {
            await context.Set<TEntity>().AddAsync(model);
            await context.SaveChangesAsync();
        }
        public virtual async Task<TEntity> Get(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }
        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }
        public virtual async Task<TEntity> FindFirstBy(Func<TEntity,bool> predicate)
        {
            return await Task.Run(()=> context.Set<TEntity>().FirstOrDefault(predicate));
        }
        public virtual async Task<IEnumerable<TEntity>> FilterBy(Func<TEntity,bool> predicate)
        {
            return await Task.Run(()=> context.Set<TEntity>().Where(predicate).ToList());
        }
        public virtual async Task Update()
        {
            await context.SaveChangesAsync();
        }
        public virtual async Task Remove(TEntity model)
        {
            context.Set<TEntity>().Remove(model);
            await context.SaveChangesAsync();
        }
    }
To be able to use it you just have to inject it in the controller specifying the Entity Type and the Context. In your example it would be like:
**Controller:**
csharp
[ApiController]
public class BaseAPIController<T> : ControllerBase
{
    private readonly GenericReposoitory<T,ExamRTContext> repository;
    public BaseAPIController(GenericRepository<T,ExamRTContext> repository) {
        this.repository = repository;
    }
    [HttpGet]
    public ActionResult<IEnumerable<T>> Get()
    {
        var entities = repository.GetAll();
        if (entities!= null) {
            return Ok(entities);
        }
        return NotFound();
    }
}
