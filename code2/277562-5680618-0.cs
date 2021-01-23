    public class MyDal
    {
        private DbSet<MyEntity> _set;
    
        public MyDal(DbContext context)
        {
            _set = context.Set<MyEntity>();
        }
    
        public IQueryable<MyEntity> GetQuery()
        {
            retur _set.Where(e => ...);
        }
    
        // Attach, Insert, Delete
    }
