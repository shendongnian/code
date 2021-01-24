    public class AdRepository<TEntity> : IAdRepository<TEntity>
        where TEntity : AdBase {
    
        public AdRepository(ApplicationDbContext dbContext) {
            //...
        }
    }
