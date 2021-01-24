    public class FitnessRepository<TEntity> : IFitnessRepository<TEntity> where TEntity :class {
        private readonly FitnessDbContextt fitnessDbContext;
    
        private readonly DbSet<TEntity> dbSet;
    
        public FitnessRepository (FitnessDbContextt context) {
            fitnessDbContext = context;
            dbSet = context.Set<TEntity> ();
    
        }
    }
