    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        protected JobsLedgerApiContext Context { get; set; }
        public virtual IQueryable<T> GetAll()
        {
            return Context.Set<T>().AsQueryable();
        }
        public virtual int Count()
        {
            return Context.Set<T>().Count();
        }
    }
