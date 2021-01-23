    public class MyContext : DbContext
    {
        private static EntityState[] states = new EntityState[] 
            { 
                 EntityState.Added,
                 EntityState.Modified,
                 EntityState.Deleted,
            };
    
        ...
    
        public override int SaveChanges()
        {
            // If Entires<IMyContract> doesn't work use Entries() and check type 
            // inside the loop
            foreach(var entry in ChangeTracker.Entries<IMyContract>()
                                              .Where(e => states.Contains(e.State))
            {
               ...
            }
        }
    }
