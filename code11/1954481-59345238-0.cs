    public interface IRepository<T> where T:class
    {
        public DbSet<T> Set
        {
            get 
            {
                var db = (DbContext)this;
                return db.Set<T>();
                
            }
        }
        public T Find(int id)
        {
            return Set.Find(id);
        }        
        
        //. . .
    }
