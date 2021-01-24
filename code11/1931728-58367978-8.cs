    public class AdPersisterFactory<TEntity> : IAdPersisterFactory<TEntity>
        where TEntity : AdBase {
    
        private readonly ApplicationDbContext dbContext;
    
        public AdPersisterFactory(ApplicationDbContext dbContext) {
            this.dbContext = dbContext;
        }
    
        public IAdPersister<TEntity> Create() {
            AdRepository<TEntity> adRepository = new AdRepository<TEntity>(dbContext);
            IAdImagePersister s3AdImagePersister = new S3AdImagePersister();
            AdPersister<TEntity> adPersister = new AdPersister<TEntity>(adRepository, s3AdImagePersister);
            return adPersister;
        }
    }
