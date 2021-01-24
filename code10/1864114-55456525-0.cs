     public static class ConnectedRepository
        {
            private static DbContext _context;
            
    
            public static SetContext(DbContext context)
            {
                _context = context;
               
            } 
    
         public static IEnumerable<TEntity> ToBindingList<TEntity>() :  where TEntity : class
                {
                    var dbSet = _context.Set<TEntity>();
                    dbSet.Load()
                    return dbSet.Local.ToBindingList();
                }
     }
    
     
