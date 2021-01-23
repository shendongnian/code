    public class GenericRepository<T> : IRepository<T> where T : class
    {
       public IQueryable<T> Find()
       {
          return _ctx.GetEntitySet<T>(); // EF plularization/reflection smarts
       }
    }
