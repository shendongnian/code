    public class Repository : IRepository
    {
    private Datacontext context;
    public Repository()
    {
        context = new Datacontext();
    }
    public IList<Entity> GetEntities()
    {
        return (from e in context.Entity
                select e).ToList();
    }
    public void Save()
    {
        context.SubmitChanges();
    }
    }
